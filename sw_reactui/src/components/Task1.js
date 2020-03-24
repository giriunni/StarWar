import React, {Component} from 'react';


export class Task1 extends Component{
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
        fetch('http://localhost:44382/api/starwarfilm/GetLongestOpeningCrawlTitle')
        .then(response => response.json())
        .then(data => {
            this.setState({taskdata: data})
            }
        )
    }

    render(){
        //const {taskdata} = this.state;
        return(
            <div className = "newline-data">
                <h4><strong>Which of all Star Wars movies has the longest opening crawl?</strong></h4>
                <h4 style={{color: "yellow"}}><strong >{this.state.taskdata}</strong></h4>                
            </div>            
        )
    }
}