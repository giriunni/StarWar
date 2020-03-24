import './Task.css';
import React, {Component} from 'react';
import Button from 'react-bootstrap/Button'
import {Task1} from './Task1'
import {Task2} from './Task2'
import {Task3} from './Task3'
import {Task4} from './Task4'

export class ToggleContainer extends React.Component{
  constructor(props) {
    super(props);

    this.state = {
        visible: false  
    };

    this.toggleButton = this.toggleButton.bind(this);
  }

  toggleButton() {
    this.setState({visible: !this.state.visible})
  }

  render(){
    return(
        <div className='overflow-scrolling'>
          <Button onClick={this.toggleButton} variant="warning" size="lg"> <h2><strong>Do. Or do not. There is no try. </strong></h2></Button>
          <br/><br/>

          <br/>
          {this.state.visible ? <Task1/> : null} 
          <br/>
          {this.state.visible ? <Task2/> : null} 
          <br/>
          {this.state.visible ? <Task3/> : null} 
          <br/>
          {this.state.visible ? <Task4/> : null} 
             
        </div>
    )
  }
}