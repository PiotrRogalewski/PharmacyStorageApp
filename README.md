# PharmacyStorageApp


				A general description of the program


      This simple program allows you to manage the dispensing and stroage of various medicines in a pharmacy
    stroage area. There are 8 categories of medicines in this app. You can manage each of them, but without more 
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


    1. Storage, dispensing and limits

         The 'PharmacyStorageApp' program allows you to store (add to medicines in stock) or dispense (remove
       from medicines in stock) medicines packages/pieces to the total quantity in a given category of
       medications in the pharmacy storage area. This pharmacy storage area have some limitations.
     
     1a. Storage - Action of adding new medicines to the storage area:
     
     ...
     
     1b. Dispensing - Action of removing from the storage area:

     ...
     
     1c. Limits

         All categories of medicines have upper limit of quantity. This upper limit is 600 packages/pieces for
       each category separately. Lower limit is 0. So for example: if storage has 0 syrups then you are not
       allowed to dispense more, if stroage has 600 syrups then no more can be added. If you try to do this
       program show you message about prohibited action and adding/removing action will be failed. As a result
       medicines in stock will has still this same quantity value then before action. This means that
       the range of available quantity is from 0 to 600 package/pieces. 
       
       (More about what happens if you are close to the lower or upper limit can be found in the description of
       the add/remove action.)

    2. Data recording

         You can choose from two options. If you want just add/remove medicicnes to/from the available total
       in program memory, then you can do it without saving this operation to a file. The second option is 
       saving to a file, so as not to lose the performed stroage management operations. The app create files
       with medicines category names, for example: "dressings_quantity.txt". In this file you can see how many and
       how often given medicine was added or substracted from total quantity of this medicine. When you finsh
       adding or substracting packages/pieces operations you can enter 'q' button to end this part and then you
       can check statistics. 

    3. Statistics 

     ...
     
     not completed... 
