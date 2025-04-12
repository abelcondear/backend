import React from "react";

class ListBooking extends React.Component {
    state = {
        booking: [{
            id: 0,
            name: "",
            booking_client: "",
            booking_date: "", 
            booking_schedule: ""
        }]
    }

    componentWillMount() {
        let current_date = new Date();
        this.setState(
            {
                booking: [
                {
                    id: 1,
                    name: "Catering",
                    booking_client: 'Rodrigo Raul',
                    booking_date: current_date.getDate() + "-" + (current_date.getMonth()+1) + "-" + current_date.getFullYear(), 
                    booking_schedule: "de 10:00 AM a 11:00 AM"
                },
                {
                    id: 2,
                    name: "Proyector",
                    booking_client: "Susana Rama",
                    booking_date: current_date.getDate() + "-" + (current_date.getMonth()+1) + "-" + current_date.getFullYear(),
                    booking_schedule: "de 12:00 PM a 01:00 PM"
                }
                ]
            }
        );
    }
  
    render() {
        return (
            <table id="BookingList" border={2} cellPadding={4}>
                <tr>
                    <td>Servicio</td>
                    <td>Cliente</td>
                    <td>Fecha</td>
                    <td>Horario</td>
                </tr>
                {this.state.booking.map(item => {
                    return (
                      <tr>
                        <td>{item.name}</td>
                        <td>{item.booking_client}</td>
                        <td>{item.booking_date}</td>
                        <td>{item.booking_schedule}</td>                     
                      </tr>
                    )
                })}            
            </table>
        );
    }
  }
  
  export default ListBooking;
  