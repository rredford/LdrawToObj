using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LdrawData;
using System.Collections;
using System.IO;
using System.Diagnostics;
using Point3DData;

//using RTree;

enum ProcessStatus : int
{
    // used for stopConvert...
    NOTSTARTED,
    STARTED,
    FORCESTOP
};

namespace LdrawData
{
    public class LdrawToData
    {
        private Stack matrices = new Stack();          // Used to store transformations stack
        private ProcessStatus stopConvert;             // force stop conversion nearly right away.
        private String inputFile;                      // directories for subparts
        private String outputFile;                     // directories for subparts
        private String sourceDir;                      // directories for subparts
        private String fileDir;                        // The directory the orginial file was found in.
        private bool line, step;                       // line and step - grouping setting.
        private bool stud, hollow, tube;               // skip parts variables
        private bool skiperror;                        // misc variables
        int linecount = 0, stepcount = 0;              // line and step count...

        PointsManager PM = new PointsManager();        // points and polys manager

        MPDFileList mpd = null;                        // MPD data file
        private bool mpdenable;                        // MPD mode variable

        int overall = 0;                               // Overall progress
        int updatecounter = 0;                         // Subpart force update progress
        const int subMax = 20;                         // How many subparts before force update?

        List<PolyShape> polylist;

        public delegate void PercentUpdateHandler(int percent);

        //debug uses...
        //StreamWriter debug = null;
        //int depth = 0;

        public event PercentUpdateHandler Percent;

        // The method which fires the Event
        protected void OnPercentUpdate(int percent)
        {
            // Check if there are any Subscribers
            if (Percent != null)
            {
                // Call the Event
                Percent(percent);
            }
        }

        public LdrawToData()
        {
            // Set default settings.
            inputFile = outputFile = sourceDir = "";
            line = step = stud = hollow = tube = false;
            skiperror = false;
            polylist = new List<PolyShape>();
            stopConvert = ProcessStatus.NOTSTARTED;
        }

        // Find file in D, PARTS or MODELS.
        // Make sure to also check Parts/S...
        private String findfile(String file)
        {
            // Try to find what directory this file is in. Its most likely in P, parts...
            //Parts is most common, followed by P.
            if (File.Exists(sourceDir + "\\PARTS\\" + file))
            {
                return sourceDir + "\\PARTS\\" + file;
            }
            if (File.Exists(sourceDir + "\\PARTS\\S\\" + file))
            {
                return sourceDir + "\\PARTS\\S\\" + file;
            }
            if (File.Exists(sourceDir + "\\P\\" + file))
            {
                return sourceDir + "\\P\\" + file;
            }
            if (File.Exists(sourceDir + "\\MODELS\\" + file))
            {
                return sourceDir + "\\MODELS\\" + file;
            }
            // Hmm not found... Return just filename, it might be in model directory.
            return fileDir + "\\" + file;
        }

        // OBJ format grouping
        private void setobjgroup(bool newline, bool newstep)
        {
            // Counts up only IF both enabled AND was selected
            // IE: Line is enabled, and it was a new line in main file.
            if (newline && line)
                linecount++;
            if (newstep && step)
                stepcount++;
        }

        // type 1, subpart file processor.
        private int type1(String[] data, bool inverted)
        {
            int color;
            double x, y, z, a, b, c, d, e, f, g, h, i;
            LdrawMatrix top = (LdrawMatrix)matrices.Peek();
            String fullpathfile;
            int res;

            // Debug
            // debug.WriteLine("peeking matrices - data: " + top.color + " " + top.x + " " +
            //    top.y + " " + top.z + " " + top.a + " " + top.b + " " + top.c + " " + top.d + " " +
            //  top.e + " " + top.f + " " + top.g + " " + top.h + " " + top.i);

            // First, was this file excluded?
            // if so, just return to caller.
            if (isExcluded(data[14]))
                return 0;

            // Process data into proper formats
            color = Int32.Parse(data[1]);

            x = Double.Parse(data[2]);
            y = Double.Parse(data[3]);
            z = Double.Parse(data[4]);

            a = Double.Parse(data[5]);
            b = Double.Parse(data[6]);
            c = Double.Parse(data[7]);

            d = Double.Parse(data[8]);
            e = Double.Parse(data[9]);
            f = Double.Parse(data[10]);

            g = Double.Parse(data[11]);
            h = Double.Parse(data[12]);
            i = Double.Parse(data[13]);

            // Is color "previous color" or "invert color"? If so, use last color.
            if (color == 16 || color == 24)
                color = top.color;

            // Now add the new transformation matrix to stack.
            addStack(color, x, y, z, a, b, c, d, e, f, g, h, i);

            // Okay the setup is ready... 
            // Try to find full path for file.
            fullpathfile = findfile(data[14]);

            //Debug.WriteLine("full file is " + fullpathfile);
            //Debug.WriteLine("just file is " + data[14]);


            // Update per subMax subfiles. prevents any GUI from lagging
            updatecounter++;
            if (updatecounter == subMax)
            {
                OnPercentUpdate(overall);
                updatecounter = 0;
            }

            // Now call processfile...
            res = processFile(fullpathfile, inverted);
            // Done with the matrix, remove it.
            matrices.Pop();
            return res;
        }

        // type 3, triangle poly processor
        private void type3(String[] data, bool inverted)
        {
            // Create and initalize values.
            int color;
            int pd1, pd2, pd3; // point place in points list

            Vector3 p1, p2, p3;
            LdrawMatrix top = (LdrawMatrix)matrices.Peek();
            p1 = new Vector3(Double.Parse(data[2]), Double.Parse(data[3]), Double.Parse(data[4]));
            p2 = new Vector3(Double.Parse(data[5]), Double.Parse(data[6]), Double.Parse(data[7]));
            p3 = new Vector3(Double.Parse(data[8]), Double.Parse(data[9]), Double.Parse(data[10]));

            // Get color to proper format
            color = Int32.Parse(data[1]);
            // Is color "previous color"? If so, use it.
            if (color == 16 || color == 24)
                color = top.color;

            // Done! Now transform it into current coorditate system
            p1 = top.transformPoint(p1);
            p2 = top.transformPoint(p2);
            p3 = top.transformPoint(p3);

            // now save points into list.
            pd1 = PM.addOrNearest(p1);
            pd2 = PM.addOrNearest(p2);
            pd3 = PM.addOrNearest(p3);

            // order of points?
            if (!inverted)
                polylist.Add(new PolyShape(3, color, linecount, stepcount, pd1, pd2, pd3, 0));
            else
                polylist.Add(new PolyShape(3, color, linecount, stepcount, pd1, pd3, pd2, 0));

            //Debug.WriteLine("polylist added one - TYPE 3");

        }

        // type 4, 4 point poly processor
        private void type4(String[] data, bool inverted)
        {
            // Create and initalize values.
            int color;
            int pd1, pd2, pd3, pd4;
            Vector3 p1, p2, p3, p4;
            LdrawMatrix top = (LdrawMatrix)matrices.Peek();
            p1 = new Vector3(Double.Parse(data[2]),  Double.Parse(data[3]),  Double.Parse(data[4]));
            p2 = new Vector3(Double.Parse(data[5]),  Double.Parse(data[6]),  Double.Parse(data[7]));
            p3 = new Vector3(Double.Parse(data[8]),  Double.Parse(data[9]),  Double.Parse(data[10]));
            p4 = new Vector3(Double.Parse(data[11]), Double.Parse(data[12]), Double.Parse(data[13]));

            // Get color to proper format
            color = Int32.Parse(data[1]);
            // Is color "previous color"? If so, use it.
            if (color == 16 || color == 24)
                color = top.color;

            // Done! Now transform it into current coorditate system
            p1 = top.transformPoint(p1);
            p2 = top.transformPoint(p2);
            p3 = top.transformPoint(p3);
            p4 = top.transformPoint(p4);

            // now save points into list.
            pd1 = PM.addOrNearest(p1);
            pd2 = PM.addOrNearest(p2);
            pd3 = PM.addOrNearest(p3);
            pd4 = PM.addOrNearest(p4);

            // order of points? 
            if (!inverted)
                polylist.Add(new PolyShape(4, color, linecount, stepcount, pd1, pd2, pd3, pd4));
            else
                polylist.Add(new PolyShape(4, color, linecount, stepcount, pd1, pd4, pd3, pd2));

            //Debug.WriteLine("polylist added one - TYPE 4");

        }

        private bool isExcluded(String filename)
        {
            bool x = false;
            // Top solid studs types.
            String s1 = "stud.dat";
            String s2 = "studp01.dat";
            // Top Hollow studs.
            String h1 = "stud2.dat";
            String h2 = "stud2a.dat";
            // Bottom Tube/Stud
            String t1 = "stud3.dat";
            String t2 = "stud3a.dat";
            String t3 = "stud4.dat";
            String t4 = "stud4a.dat";

            // Force lower to match strings
            String l = filename.ToLower();

            //debug.WriteLine("is this one excluded? " + l);

            if (stud)                     // Regular stud and elecric stud
            {
                x = (l.CompareTo(s1) == 0 || l.CompareTo(s2) == 0);
                if (x)
                    return x;
            }

            if (hollow)                   // regular hollow top and no line on bottom
            {
                x = (l.CompareTo(h1) == 0 || l.CompareTo(h2) == 0);
                if (x)
                    return x;
            }

            if (tube)                     // 4 types of bottom parts thats usually hidden
            {                                         // such as tubes, rods.
                x = (l.CompareTo(t1) == 0 || l.CompareTo(t2) == 0 ||
                    l.CompareTo(t3) == 0 || l.CompareTo(t4) == 0);
                if (x)
                    return x;
            }
            //debug.WriteLine("Nope...");
            return false;
        }

        private void addStack(int color, double x, double y, double z, double a, double b,
                           double c, double d, double e, double f, double g, double h,
                           double i)
        {
            // Create a new stack with those paramaters.
            LdrawMatrix newone = new LdrawMatrix(color, x, y, z, a, b, c, d, e, f, g, h, i);

            if (matrices.Count != 0)
            {
                double aa, bb, cc, dd, ee, ff, gg, hh, ii;
                Vector3 p = new Vector3(x, y, z);

                LdrawMatrix top = (LdrawMatrix)matrices.Peek();

                // Trandform matrix to last coordate system
                // Creating new matrix that does both transformations in one step.
                
                aa = (top.a * newone.a) + (top.b * newone.d) + (top.c * newone.g);
                dd = (top.d * newone.a) + (top.e * newone.d) + (top.f * newone.g);
                gg = (top.g * newone.a) + (top.h * newone.d) + (top.i * newone.g);

                bb = (top.a * newone.b) + (top.b * newone.e) + (top.c * newone.h);
                ee = (top.d * newone.b) + (top.e * newone.e) + (top.f * newone.h);
                hh = (top.g * newone.b) + (top.h * newone.e) + (top.i * newone.h);

                cc = (top.a * newone.c) + (top.b * newone.f) + (top.c * newone.i);
                ff = (top.d * newone.c) + (top.e * newone.f) + (top.f * newone.i);
                ii = (top.g * newone.c) + (top.h * newone.f) + (top.i * newone.i);

                //Now transform point into stack current coord...
                p = top.transformPoint(p);

                // All finished. Now fill in results into matrix then push it in.
                newone.x = p.X;
                newone.y = p.Y;
                newone.z = p.Z;
                newone.a = aa;
                newone.b = bb;
                newone.c = cc;
                newone.d = dd;
                newone.e = ee;
                newone.f = ff;
                newone.g = gg;
                newone.h = hh;
                newone.i = ii;
                matrices.Push(newone);
            }
        }

        int d = 0;
        private void depth(int x)
        {
            d += x;
            //Debug.WriteLine("depth" + d.ToString() + "################################################ depth " + d.ToString());
        }

        // Actual processing file section
        // reads file and open sub-part files or performs transitions as nesscary.
        // parameter root is used to tell processFile that its an orginial file and not a subpart.
        private int processFile(String file, bool inverted, bool root = false)
        {
            depth(1);
            StreamReader RF = null;
            LdrawMatrix work = null;
            String line = null;
            String[] s = null;
            String[] space = { " " };// Used for split line
            bool thisOneInverted = false;// Remember where it was flagged inverted.

            work = (LdrawMatrix)matrices.Peek();

            // If processing a MPD file, priority is always subparts in MPD first.
            if (mpdenable)
            {
                String a = Path.GetFileName(file);
                //Debug.WriteLine("checking mpd subpart. part being found out is " + a);
                RF = mpd.getMPDSubpart(a);
                //if (RF != null)
                //{
                    //Debug.WriteLine("Got a subpart... with " + a);

                    //a = RF.ReadLine();
                    //Debug.WriteLine("#### debug print this main file");
                    // debug
                    //while (a != null)
                    //{
                    //  Debug.WriteLine(a);
                     //   a = RF.ReadLine();
                    //}
                    //RF.BaseStream.Seek(0L,0);
                //}
            }

            // If RF is still null (or theres no MPD to use) load file
            if (RF == null)
            {
                //Check if file exists. The handle according.
                bool err = File.Exists(file);
                if (!err && !skiperror)
                {
                    depth(-1);
                    return 1; // ignore errors not enabled, return with error
                }
                else if (!err && skiperror)
                {
                    depth(-1);
                    return 0; // Return "its fine" even if file was not processed. (ignorerrors enabled)
                }
                RF = new StreamReader(file);
                // Was open a failure? if so return error.
                if (RF == null)
                {
                    depth(-1);
                    return 1; // Hard error, cannot be skipped
                }
            }

            // Was stop requested?
            if (stopConvert == ProcessStatus.FORCESTOP)
            {
                stopConvert = ProcessStatus.NOTSTARTED;
                RF.Close();
                depth(-1);
                return 100;
            }

            // Check only when mpd isnt enabled.
            if (root && !mpdenable)
            {
                // Get root folder if it was root file...
                // Used for findfile default if not found in source directories.
                fileDir = Path.GetDirectoryName(file);
                //Debug.WriteLine(fileDir);
                //Debug.WriteLine(Path.GetExtension(file));
                // Check if its MPD type
                if (Path.GetExtension(file).ToLower().CompareTo(".mpd") == 0)
                {
                    RF.Close();
                    mpd = new MPDFileList(file);
                    RF = mpd.getMPDSubpart(null);
                    mpdenable = true; // enable mpd mode
                    // String a = RF.ReadLine();
                    //Debug.WriteLine("#### debug print this main file");
                    // debug
                    //while (a != null)
                    //{
                    //  Debug.WriteLine(a);
                    //    a = RF.ReadLine();
                    //}
                    //RF.BaseStream.Seek(0L,0);
                }
            }

            // Read first line
            line = RF.ReadLine();
            //if (root)
            //    Debug.WriteLine(line + " // read");
            while (line != null)
            {
                if (root)
                {
                    overall = (int)(((double)RF.BaseStream.Position / (double)RF.BaseStream.Length) * 100.0);
                    OnPercentUpdate(overall);
                }

                // Split line into "words"
                s = line.Split(space, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length >= 1)
                {
                    switch (s[0])
                    {
                        case "0":// Comment, invertnext or step.
                            if (s.Length > 1 && s[1].CompareTo("STEP") == 0)
                            {
                                // step found!
                                setobjgroup(false, true);
                                //debug.WriteLine("step found.");

                            }
                            // Is it invert next? it should be in format 0 BFC INVERTNEXT.
                            else if (s.Length > 2 && s[1].CompareTo("BFC") == 0 && s[2].CompareTo("INVERTNEXT") == 0)
                            {
                                // 0 BFC INVERTNEXT found!
                                inverted = !inverted;
                                thisOneInverted = true;
                                //debug.WriteLine("invert next found. Status now " + inverted);
                            }
                            break;
                        case "1":// new subpart file...
                            //Debug.Write("subpart found... legit: ");
                            if (s.Length < 14)
                            {
                                //Debug.WriteLine("no!");
                                // error!
                                RF.Close();
                                return 1;
                            }
                            else
                            {
                                //Debug.WriteLine("yes");
                                // If this is in root file, start a new line group
                                if (root)
                                    setobjgroup(true, false);

                                //debug.WriteLine("////////////////////////////////////////////////////////////////////////////////");
                                //debug.WriteLine("New subpart: " + s[14] + " depth: " + ++depth + " matrices size: " + matrices.ToArray().Length);
                                int x = type1(s, inverted);
                                //if(root)
                                  //  Debug.WriteLine("type1 exit... X:" + x + " line:" + line);

                                //debug.WriteLine("Leaving subpart. Depth: " + --depth + " matrices size: " + matrices.ToArray().Length);
                                //debug.WriteLine("////////////////////////////////////////////////////////////////////////////////");
                                if (x != 0)
                                {
                                    depth(-1);
                                    return x; 
                                }
                            }
                            if (thisOneInverted)// Was here where invert was enabled? if so it should be flipped.
                            {
                                inverted = !inverted;
                                thisOneInverted = false;
                                //debug.WriteLine(" was inverted, undoing now. status: " + inverted);
                            }
                            break;
                        case "3":// Triangle
                            //debug.Write("type 3... legal: ");
                            if (s.Length < 11)
                            {
                                //debug.WriteLine("no!");
                                // error!
                                RF.Close();
                                depth(-1);
                                return 1;
                            }
                            else
                            {
                                //debug.WriteLine("yes");
                                type3(s, inverted);
                            }
                            if (thisOneInverted)// Was here where invert was enabled? if so it should be flipped.
                            {
                                inverted = !inverted;
                                thisOneInverted = false;
                                //debug.WriteLine(" was inverted, undoing now. status: " + inverted);
                            }
                            break;
                        case "4":// Quad
                            //debug.Write("type 4... legal: ");
                            if (s.Length < 14)
                            {
                                // debug.WriteLine("no!");
                                // error!
                                RF.Close();
                                depth(-1);
                                return 1;
                            }
                            else
                            {
                                // debug.WriteLine("yes");
                                type4(s, inverted);
                            }
                            if (thisOneInverted)// Was here where invert was enabled? if so it should be flipped.
                            {
                                inverted = !inverted;
                                thisOneInverted = false;
                                //debug.WriteLine(" was inverted, undoing now. status: " + inverted);
                            }
                            break;
                    }
                    //if(root)
                      //  Debug.WriteLine("Exit select case");
                }
                // Read next line
                //if(root)
                  //  Debug.WriteLine(line + " after processed.");
                line = RF.ReadLine();
                //if (root)
                  //  Debug.WriteLine(line + " // read");
            }


            // Clean up
            RF.Close();
            depth(-1);

            return 0;
        }

        // The function that external class can call to initate process
        public int Start(String sou, String inp, String outp,                  // source, input, then output
                       bool lineGroup, bool stepGroup,                         // Grouping options
                       bool noStuds, bool noHollowStuds, bool noBottomTubes,   // Skip parts options
                       bool ignoreErrors)                            // Ignore file errors
        {
            int x = 0;
            StreamWriter WF = null;                    // current written file.


            // Process have started
            stopConvert = ProcessStatus.STARTED;

            PM.clear();

            // Check if all strings is not empty
            if (sou.CompareTo("") == 0 || inp.CompareTo("") == 0 || outp.CompareTo("") == 0)
                return 1;
            else
            {
                sourceDir = sou;
                inputFile = inp;
                outputFile = outp;
            }

            // Check if source directory and input file exists...
            if (!File.Exists(inputFile) || !Directory.Exists(sourceDir))
            {
                return 1;
            }

            // Set parameters
            line = lineGroup;
            step = stepGroup;
            stud = noStuds;
            hollow = noHollowStuds;
            tube = noBottomTubes;
            skiperror = ignoreErrors;
            linecount = 0;
            stepcount = 0;

            // debug file open.
            //debug = new StreamWriter(outp + ".DEBUG.txt");
            //if (debug == null)
            //{
            //Message( (char*) "Error: File cannot be created. Check disk space left?", (char*) "2" );
            //    stopConvert = ProcessStatus.NOTSTARTED;
            //    debug.Close();
            //    return 2;
            //}

            //debug.WriteLine("grouping options: " + line + " " + step);
            //debug.WriteLine("grouping options paras: " + lineGroup + " " + stepGroup);

            //debug.AutoFlush = true;

            //debug.WriteLine("Debug for " + inputFile + " output is: " + outputFile);
            //debug.WriteLine("////////////////////////////////////////////////////////////////////////////////");

            // Push in initial matrix = ID4.
            matrices.Push(new LdrawMatrix());


            // Lets do the actual conversion.
            // Also set root to true (4th parameter)
            x = processFile(inp, false, true);

            // Open write file and check error
            WF = new StreamWriter(outp);
            if (WF == null)
            {
                stopConvert = ProcessStatus.NOTSTARTED;
                WF.Close();
                return 2;
            }

            // Okay, now write file.
            if(x == 0)
            {
                x = WriteToObj.writeObj(WF, PM.points, polylist, line, step);
            }

            WF.Close();

            // Clean up
            stopConvert = ProcessStatus.NOTSTARTED;
            matrices.Clear();


            PM.clear();
            //debug.Close();

            return x;
        }

        public void Stop()
        {
            if (stopConvert == ProcessStatus.STARTED)
                stopConvert = ProcessStatus.FORCESTOP;
        }


    
    
    
    
    }
}
