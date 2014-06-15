LdrawToObj
==========

Converts LDraw model files to OBJ.

What needs to be done:

1: Custom color support, for example color #432112.
    a) add Color object to store value till it is ready to be written into mtl file.
    b) it should create <modelfilename>.mtl for custom colors, but only if there is actual custom colors. Ldrawcolors.mtl is for standard ldraw colors.
    
    

2:) Remove useless project from source. I refactored in middle of development to make it function better but left now useless files.
