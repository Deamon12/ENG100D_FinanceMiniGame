Author: Anshul Chandan
Email: achandan@ucsd.edu
       ani0026@yahoo.com
Date: 6/21/2016

JOB UP! Mini-Game Extension Guide
---------------------------------
The main purpose of this guide is to inform future developers how to easily add
new categories. This is a fairly simple process and most people (even non-
developers) should be able to complete the process.

ADDING A NEW CATEGORY
---------------------
1) Navigate to the CategoryScreen Scene in Unity
2) Use the "Button" prefab (Assets > Prefabs) to create a new button within the
   content section of the Scroll View (Scroll View > Viewport > Content).
3) Edit the text to be the name of the category and re-arrange the buttons so
   that they are in alphabetical order.
4) Open the Buttons.cs file (Assets > Scripts)
5) Add the title, category description, and index by following the format in
   the commment at the top of the file
6) Write a method below the ChangeRightSide method as follows:
   public void CatNameInCamelCase() {
	ChangeRightSide(ABBREVIATEDCATNAME_TITLE, ABBREVIATEDCATNAME_STR);
   }
7) Add a text file with all the terms you want to be in the new category. The
   name of this file MUST BE exactly the same as the string used for the 
   ABBREVIATEDCATNAME_TITLE variable.
8) Add a text file with all the descriptions for each term in the category. The
   name of this file MUST BE Category Name_Desc.txt. The format is as follows 
   (or you can follow the format of Interview_Desc.txt):
   Term	Description
9) Go back to Unity and click on the Button you made. Scroll down in the
   inspector until you see the "On Click" component. 
10) Click on the plus button and drag the "CategoryController" from the hierarchy
    to the slot for the object. Then, in the drop down menu select the method you
    just created (Buttons > CatNameInCamelCase()).
11) You just added a new category to the game!

EDITING A PREVIOUSLY CREATED CATEGORY
-------------------------------------
A) Editing Term: Simply open the text file of the category you want to edit and 
		 make your changes there. Be sure to save and close.
B) Editing Descriptions: Simply open the text file of the descriptions for the 
			 category you want to edit. Follow the previously stated
			 format. Be sure to save and close.
