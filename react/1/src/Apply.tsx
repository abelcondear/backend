import React from "react";
 
class Apply extends React.Component {
    state = {

        service: [
            {
                id: 0,
                name: "",
            }            
        ],
        time: [
            {
                id: 0,
                from: "",
                to: ""
            }
        ]
    }

    componentWillMount() {
        let current_date = new Date();

        this.setState(
            {
                selected_service: "",
                service: [
                {
                    id: 1,
                    name: "Catering",
                },
                {
                    id: 2,
                    name: "Proyector",
                }
                ],
                time: [
                {
                    id: 1,
                    from: "10:00 AM",
                    to: "11:00 AM"
                },
                {
                    id: 2,
                    from: "11:00 AM",
                    to: "12:00 PM"
                },
                {
                    id: 3,
                    from: "11:00 AM",
                    to: "12:00 PM"
                },                         
                {
                    id: 4,
                    from: "12:00 PM",
                    to: "01:00 PM"
                },
                {
                    id: 5,
                    from: "01:00 PM",
                    to: "02:00 PM"
                },
                {
                    id: 6,
                    from: "02:00 PM",
                    to: "03:00 PM"
                },
                {
                    id: 7,
                    from: "03:00 PM",
                    to: "04:00 PM"
                },
                {
                    id: 8,
                    from: "04:00 PM",
                    to: "05:00 PM"
                },
                {
                    id: 9,
                    from: "05:00 PM",
                    to: "06:00 PM"
                }                                                                                
                ] 
            }
        );
    }

    render() {
        function book() {
            let ob_service = document.getElementById("service");

            let items = {
                name: "Catering",
                booking_client: "Sebastian Rivera",
                booking_date: "2025-04-11",
                booking_schedule: "de 10:00 AM a 11:00 AM"
            };

            fetch("http://localhost:5000/booking-save?json="+encodeURI(JSON.stringify(items)), {
                mode: 'no-cors',
                headers: {
                    'Access-Control-Allow-Origin':'*',
                    'Access-Control-Request-Method':'POST',
                    'Access-Control-Request-Headers':'Content-Type',
                    'Content-Type':'application/json'
                },                
                method: "POST",
                body: JSON.stringify(items)
            });
            
            let tbl = document.getElementById("BookingList");
            let tr = document.createElement("tr");
            
            let td = document.createElement("td");
            td.innerText = "Catering";
            tr.append(td);

            td = document.createElement("td");
            td.innerText = "Sebastian Rivera"
            tr.append(td);

            td = document.createElement("td");
            td.innerText = "11-04-2025";
            tr.append(td);
            
            td = document.createElement("td");
            td.innerText = "de 10:00 AM a 11:00 AM";
            tr.append(td);
            
            tbl?.append(tr);
        }

        return (
            <table border={2} cellPadding={4}>
                <tr>
                    <td>Servicio</td>
                    <td>
                        <select id="service">
                        {this.state.service.map(item => {
                            return (
                                <option value="{item.id}">{item.name}</option>
                            )
                        })}
                        </select>                        
                    </td>
                    <td>Cliente</td>
                    <td><input type="text" id="client" size={10} /></td>
                    <td>Horario</td>
                    <td>
                        <select id="time">
                        {this.state.time.map(item => {
                            return (
                                <option value="{item.id}">de {item.from} a {item.to}</option>
                            )
                        })}
                        </select>                        
                    </td>
                    <td>
                        <button onClick={book}>Reservar</button>
                    </td>
                </tr>
            
            </table>
        );
    }
  }
  
  export default Apply;
  