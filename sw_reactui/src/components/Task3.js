import React, {Component} from 'react';


export class Task3 extends Component{
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
        fetch('http://localhost:44382/api/starwarfilm/GetMostAppearedSpeciesWithCount')
        .then(response => response.json())
        .then(data => {
            this.setState({taskdata: data})
            }
        )
    }
    render(){
        return(
            <div className = "newline-data">
                <h4><strong>What species appeared in the most number of Star Wars films?</strong></h4>
                <h4 style={{color: "yellow"}}><strong >{this.state.taskdata}</strong></h4>                
            </div>            
        )
    }
}