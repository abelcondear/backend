import json 
import sqlite3
import random
from flask import Flask, jsonify, request

app = Flask(__name__)
app.secret_key = '05555_1'

db_filename = "booking.db"

@app.route('/booking-list', methods=['GET'])
def booking_list():
    if request.method == 'GET':
        with sqlite3.connect(db_filename) as conn:
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM booking")   
            rows = cursor.fetchall()
            return jsonify(rows)
    else:
        return jsonify([()])

@app.route('/service-list', methods=['GET'])
def service_list():
    if request.method == 'GET':
        with sqlite3.connect(db_filename) as conn:
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM service")   
            rows = cursor.fetchall()
            return jsonify(rows)
    else:
        return jsonify([()])

@app.route('/client-list', methods=['GET'])
def client_list():
    if request.method == 'GET':
        with sqlite3.connect(db_filename) as conn:
            cursor = conn.cursor()
            cursor.execute("SELECT * FROM client")   
            rows = cursor.fetchall()
            return jsonify(rows)
    else:
        return jsonify([()])

@app.route('/booking-save', methods=['POST'])
def booking_save():
    if request.method == 'POST':      
        id = random.randint(100, 900)
        value = request.args.get("json")
        data = json.loads(value)
        
        name = data["name"]
        booking_client = data["booking_client"]
        booking_date = data["booking_date"]
        booking_schedule = data["booking_schedule"]

        with sqlite3.connect(db_filename) as conn:
            cursor = conn.cursor()   
            
            sql = "INSERT INTO booking(id, name, booking_client, booking_date, booking_schedule)" 
            sql += f"VALUES({id}, '{name}', '{booking_client}', '{booking_date}', '{booking_schedule}');"

            cursor.execute(sql)  
            conn.commit()
            return jsonify([(id,name,booking_client,booking_date,booking_schedule)])
    else:
        return jsonify([()])           

if __name__ == '__main__':
    app.run()