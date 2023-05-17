# PharmacyStorageApp


				A general description of the program


    This simple program allows you to manage the dispensing and storage of various medicines in a pharmacy
    storage area. There are 8 categories of medicines in this app. You can manage each of them, but without more 
    specific details such as medicine proper name or composition etc, only main categories. Below you can find
    this categories:

    1) painkillers,
    2) other tablets,
    3) syrups,
    4) suppositories,
    5) dressing,
    6) ointment,
    7) drops,
    8) supplements,

    In this app you can find more information about each of this 8 categories. When you will see statistics
    you can check information such as: state of matter, type of packaging, total package capacity. More about
    statistics you find below.


				Program details


    I. Storage, dispensing and limits

	The 'PharmacyStorageApp' program allows you to store (add to medicines in stock) or dispense (remove
	from medicines in stock) medicines packages/pieces to the total quantity in a given category of
	medications in the pharmacy storage area. This pharmacy storage area have some limitations.
     
    1. Limits

	All categories of medicines have upper limit of quantity. This upper limit is 600 packages/pieces for
	each category separately. Lower limit is 0. So for example: if storage has 0 syrups then you are not
	allowed to dispense more, if stroage has 600 syrups then no more can be added. If you try to do this
	program show you message about prohibited action and adding/removing action will be failed. As a result
	medicines in stock will has still this same quantity value then before action. This means that
	the range of available quantity is from 0 to 600 pieces. 
       
	More about what happens if you are close to the lower or upper limit can be found below.

    2. Storage - Action of adding new medicines to the storage area:
     
	You can add new medicines to the storage area in the main menu when you choose Add option by writing 
	'add' or '1' and then pressing Enter. Usually you may add from the range of 1-100 pieces (pcs) at once. 
	There are some exceptions. This exceptions appears when you choosed saving to the file and you are close
	to upper limit while adding. When you have 500 medicines in stock you are still able to add 1-100 pcs, 
	but if you have 501-550 meds in your storage area then you can only add 1-50 pcs at once. When there is
	551-575 medicines then you may add 1-25 pcs. In case in this stroage area is 576-590 meds then you can add
	1-10 pcs. Last exception for adding medications is when you have 591-599 medicines in stock, then you may
	add only 1 pcs at once. The closer you are to the upper limit, the less you can add. 

    3. Dispensing - Action of removing from the storage area:

	In case you want to remove medicines from the storage area you should choose Remove option in the main menu
	by writing 'remove' or '2' and then pressing ENTER. If your selection at the beginning was saving to 
	the program memory then you may remove 0,1 - 20 medicines at once. When your selection was saving to 
	the file then you may also remove 0,1 - 20 medcines at once but if you are close to 0 medicines in stock 
	this range is changing. In case in the storage area is 10-19 medicines you can remove 0,1 - 10 meds at once. 
	If there is 5 - 9 medicines then you can remove 0,1 - 5. In case there is 0,1 - 4 medicines you can remove 
	0,1 - 1 meds. Similarly to the action of adding, the closer to the limit, the less you can remove.

    II. Value for texts and letters.

	Below you can find text and letter value.
    	
	
	Text value for adding action:
 
	- for these texts this value is 100 pcs:
	  "max" or "maximum" or "huge cardboard" or "huge" or "huge medicines cardboard" or
	  "a huge box of medicines" or "a huge medicine box",

        - for these texts this value is 50 pcs:
	  "large" or "big" or "big cardboard" or "big box" or "big medicines cardboard" or
	  "a large box of medicines" or "a large medicine box",

        - for these texts this value is 25 pcs:
	  "medium" or "medium cardboard" or "medium box" or "medium medicine carton" or "carton" or "cardboard"
	  or "box" or "twenty five pieces" or "25 pieces" or "twenty-five",

        - for these texts this value is 10 pcs: 
	  "min" or "minimum" or "small" or "small cardboard" or "small box" or "ten pieces" or
	  "10 pieces" or "ten".


	Letter value for adding action:

	- for letter: 'a' or 'A' - this value is 100 pcs,
	- for letter: 'b' or 'B' - this value is 90 pcs,
	- for letter: 'c' or 'C' - this value is 80 pcs,
	- for letter: 'd' or 'D' - this value is 70 pcs,
	- for letter: 'e' or 'E' - this value is 60 pcs,
	- for letter: 'f' or 'F' - this value is 50 pcs,
	- for letter: 'g' or 'G' - this value is 40 pcs,
	- for letter: 'h' or 'H' - this value is 30 pcs,
	- for letter: 'i' or 'I' - this value is 20 pcs,
	- for letter: 'j' or 'J' - this value is 10 pcs,
	- for letter: 'k' or 'K' - this value is 5 pcs.


	Letter value for removing action:

	- for letter: 'l' or 'L' - this value is -1 pcs,
	- for letter: 'm' or 'M' - this value is -5 pcs,
	- for letter: 'n' or 'N' - this value is -10 pcs,
	- for letter: 'o' or 'O' - this value is -20 pcs,
     

    III. Data recording

	You can choose from two options. First option is saving to the program memory. In this case you can
	add or remove medicicnes to/from the available total in the program memory without saving this operations
	to a file. The program will remember all your actions and it will count statistics until you close console
	window. After you choose to exit from the program your data such as medicine in stock, and all statistics 
	will be lost. 
	
	The second option is saving to a file. For the first time - after you choose category of medicines, the 
	app create file with selected medicine category name, for example: "dressings_quantity.txt". In this file
	you can see how many and how often given medicine was added or substracted from total quantity of this
	medicine. It will be string of numbers. Everything in the program will be similar like in case of saving 
	data to the program memory, however when you close this app console window and start program from the 
	beginning your data will be still there. So you can check your actions from before and make new actions, 
	everything will be included in the statistics.

    IV. Statistics 

	All statistics you can check in the program but not in the file. When you finsh adding or substracting
	packages/pieces operation you should click 'q' button and then pres ENTER button to end this part and 
	then you can check statistics. You can also check it from the main menu, even if you don't do any action
	yet. In that case you will see informations about no actions. You may do action of adding and action of 
	removing several times. The program calculates statistics on a regular basis.
