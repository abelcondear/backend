import sqlite3
import os
import json

db_filename= "booking.db"
directory = r"../sqlite/"
print("Connecting database ...")

with sqlite3.connect(db_filename) as conn:    
    for name in os.listdir(directory):
        with open(os.path.join(directory, name)) as f:
            print(f"Reading '{name}'")
            content = f.read()

            try:                
                cursor = conn.cursor()

                print("Executing script ...")

                if name.find("-select-") == -1:                        
                    cursor.executescript(content)  
                    conn.commit()           
                else:
                    cursor.execute(content)   
                    rows = cursor.fetchall()
                    for row in rows:
                        print(row)

                    print("")
                    print("Printing json format ..")
                    print(json.dumps(rows))                                                 

                print("Done")

            except sqlite3.OperationalError as e:
                print(e)
   
    print("")
    print("Finished")
