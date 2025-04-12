DELETE FROM booking;

INSERT INTO booking(id, name, booking_client, booking_date, booking_schedule)
VALUES(1, 'Catering', 'Fernando Gimenez', DATE(), 'de 10:00 AM a 11:00 AM');

INSERT INTO booking(id, name, booking_client, booking_date, booking_schedule)
VALUES(2, 'Proyector', 'Laura Fasco', DATE(), 'de 12:00 PM a 01:00 PM');

INSERT INTO booking(id, name, booking_client, booking_date, booking_schedule)
VALUES(3, 'Iluminacion', 'Maria Larrea', DATE(), 'de 01:00 PM a 02:00 PM');