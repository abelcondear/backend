import os
import findspark

os.environ["JAVA_HOME"] = "C:\\Program Files\\Java\\jdk-11.0.2"
os.environ["SPARK_HOME"] = "C:\\spark-3.2.4-bin-hadoop2.7"

findspark.init()

import time

from pyspark.context import SparkContext
from pyspark.conf import SparkConf
from pyspark.sql import SparkSession

sc = SparkContext('local[*]')
time.sleep(5) #needs time to create context before creating session

spark = (
    SparkSession
        .builder
        .appName("programming")
        .master("local[*]")                                        
        .config("spark.jars.packages", ",io.delta:delta-core_2.12:1.1.1") 
        .config("spark.sql.extensions", "io.delta.sql.DeltaSparkSessionExtension")
        .config("spark.sql.catalog.spark_catalog", "io.delta.sql.delta.catalog.DeltaCatalog")
        .config('spark.ui.port', '4050')
        .getOrCreate()
)


# function to create RDD
def create_RDD(sc_obj, data):
    df = sc.parallelize(data)
    return df

# function to convert RDD to list
def read_RDDCollection(rdd_collection):
    result = []

    for rdd in rdd_collection:
        ls = rdd.collect()
        is_header=False

        for item in ls:
            if not is_header:
                is_header = True
                continue
            else:
                result.append(tuple(item.split(",")))

    return result

string_20210609 = '''worked_date,employee_id,delete_flag,hours_worked
2021-06-09,1001,N,7
2021-06-09,1002,N,3.75
2021-06-09,1003,N,7.5
2021-06-09,1004,N,6.25'''

string_20210610 = '''worked_date,employee_id,delete_flag,hours_worked
2021-06-10,1001,N,8
2021-06-10,1002,N,6
2021-06-10,1003,N,1
2021-06-10,1004,N,10'''

string_20210611 = '''worked_date,employee_id,delete_flag,hours_worked
2021-06-11,1001,N,6
2021-06-11,1002,N,7
2021-06-11,1003,N,9
2021-06-11,1004,N,5
2021-06-10,1003,Y,1
2021-06-10,1004,N,8'''

rdd_20210609 = create_RDD(sc, string_20210609.split('\n'))
rdd_20210610 = create_RDD(sc, string_20210610.split('\n'))
rdd_20210611 = create_RDD(sc, string_20210611.split('\n'))

rows_202106 = read_RDDCollection([rdd_20210609,rdd_20210610,rdd_20210611])
index = 0

message_warning = []
message_information = []

for row in rows_202106:
    employee_count = 0
    employee_warn_count = 0

    for rowb in rows_202106:
        worked_date = row[0]
        employee_id = row[1]
        delete_flag = row[2]
        
        worked_dateb = row[0]
        employee_idb = rowb[1]
        delete_flagb = rowb[2]

        if (employee_id == employee_idb and worked_date == worked_dateb):
            employee_warn_count += 1
            if employee_warn_count > 1:
                message_warning.append(f"Warning: Employee ID {employee_id} was found more than once during the same day [{worked_date}].")

        if (employee_id == employee_idb) and (delete_flag == 'Y' or delete_flagb == 'Y'):
            employee_count += 1
            if employee_count > 1:
                rows_202106.pop(index)
                message_information.append(f"Information: Employee ID {employee_id} was deleted because flag=Y.")

    index += 1

message_warning = list(set(message_warning))
message_information = list(set(message_information))

message_warning.sort()
message_information.sort()

print("\n\n")

for message in message_warning:
    print(message)

for message in message_information:
    print(message)

print("\n\n")

print("Exercise\\Output:")
print("worked_date|employee_id|delete_flag|hours_worked")
for row in rows_202106:
    print(f"{row[0]}|{row[1]}|{row[2]}|{row[3]}")

print("\n\n")

# save data into single dataframes (on the fly)
l_df = []
for row in rows_202106:
    df=spark.sql(f"SELECT '{row[0]}' ,'{row[1]}' ,'{row[2]}' ,'{row[3]}'")
    l_df.append(df)

# print out dataframes
for df in l_df:
    print(df)

print("\n\n")

# terminal output sample
"""
Exercise\Output:
worked_date|employee_id|delete_flag|hours_worked
2021-06-09|1001|N|7
2021-06-09|1002|N|3.75
2021-06-09|1003|N|7.5
2021-06-09|1004|N|6.25
2021-06-10|1001|N|8
2021-06-10|1002|N|6
2021-06-10|1003|N|1
2021-06-10|1004|N|10
2021-06-11|1001|N|6
2021-06-11|1002|N|7
2021-06-11|1003|N|9
2021-06-11|1004|N|5

DataFrame[2021-06-09: string, 1001: string, N: string, 7: string]
DataFrame[2021-06-09: string, 1002: string, N: string, 3.75: string]
DataFrame[2021-06-09: string, 1003: string, N: string, 7.5: string]
DataFrame[2021-06-09: string, 1004: string, N: string, 6.25: string]
DataFrame[2021-06-10: string, 1001: string, N: string, 8: string]
DataFrame[2021-06-10: string, 1002: string, N: string, 6: string]
DataFrame[2021-06-10: string, 1003: string, N: string, 1: string]
DataFrame[2021-06-10: string, 1004: string, N: string, 10: string]
DataFrame[2021-06-11: string, 1001: string, N: string, 6: string]
DataFrame[2021-06-11: string, 1002: string, N: string, 7: string]
DataFrame[2021-06-11: string, 1003: string, N: string, 9: string]
DataFrame[2021-06-11: string, 1004: string, N: string, 5: string]
"""
