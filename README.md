# PharmacyStorageApp

A general description of the program:

  This simple program allows you to manage the dispensing and stroage of various medicines in a pharmacy stroage area. In this program you have 7 categories of medicines that you can manage but without more specific details like medicine proper name or composition etc, only main categories. Below you can find more about this categories:  
1) painkillers,
2) other tablets,
3) syrups,
4) suppositories,
5) dressing,
6) ointment,
7) drops.


Program details:

1. Storage, dispensing and limits

  The 'PharmacyStorageApp' program allows you to store (add to the available total) and dispense (subtracted from the available total) medicine packages/pieces to the total quantity in a given category in the pharmacy storage area. This pharmacy storage area have some limitations. All categories of medicines have upper limit of quantity (limited storage area). This upper limit is 600 packages/pieces for each category separately. Lower limit is 0. So for example: if storage has 0 syrups then you are not allowed to dispense more, if stroage has 600 syrups then no more can be added. If you try to do this program show you message about prohibited action and adding/substracting action will be failed. So total quantity will has still this same quantity value then before action. This means that the range of available quantity is from 0 to 600 package/pieces. 

2. Data recording and statistics

  You can choose from two options. If you want just add/substract packages/pieces to/from the available total in program memory, then you can do it without saving this operation. The second option is saving to a file, so as not to lose the performed stroage management operations. The program create files with medicine category names, for example: "dressings_quantity.txt". In this file you can see how many and how often given medicine was added or substracted from total quantity of this medicine. When you finsh adding or substracting packages/pieces operations you can enter 'q' button to end this part and then you can check some statistics. 

...to be continue
  ...(this file is not ready)...
