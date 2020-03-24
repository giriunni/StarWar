import React, {Component} from 'react';

export class Task4 extends Component{
    constructor(props) {
        super(props);
    
        this.state = {
            taskdata: ""  
        };
    }

    componentDidMount(){
        this.getAPIData();
    }

    getAPIData()
    {
        fetch('http://localhost:44382/api/starwarfilm/GetLargestNumberOfVehiclePilot')
        .then(response => response.json())
        .then(data => {
            this.setState({taskdata: data})
            }
        )
    }
    render(){
        return(
            <div className = "newline-data">
                <h4><strong>What planet in Star Wars universe provided largest number of vehicle pilots?</strong></h4>
                <h4 style={{color: "yellow"}}><strong >{this.state.taskdata}</strong></h4>                
            </div>            
        )
    }
}