import React, { Component } from 'react';
import './PartList.css';
import PartForm from '../PartForm/PartForm';
import { makeStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import { FaPlusSquare } from 'react-icons/fa';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import CancelIcon from '@material-ui/icons/Cancel';
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import Input from '@material-ui/core/Input';
import FormHelperText from '@material-ui/core/FormHelperText';
import Button from '@material-ui/core/Button';
import SaveIcon from '@material-ui/icons/Save';

class PartList extends Component {
    constructor() {
        //I don't need props passed into constructor(or the super method), because 
        //I'm not using them in the constructor, or at all in this component
        //..for now
        super();

        this.state = {
            parts: [],
            showNew: false,
            newPart: {}
        };

        //This makes it so you can use the 'this' keyword in the click method
        this.newItemClick = this.newItemClick.bind(this);
        this.submitNewItem = this.submitNewItem.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.retrieveData = this.retrieveData.bind(this);
    }

    componentDidMount() {
        this.retrieveData();
    }

    retrieveData(){
        fetch('https://localhost:5001/api/todo')
            .then(response => response.json())
            .then(data => this.setState({ parts: data }));
    }

    handleChange(event) {

        const target = event.target;
        const value = target.value;
        const name = target.id;
        let newPart = this.state.newPart;
        newPart[name] = value;
        this.setState({
          newPart: newPart
        });
      }

    newItemClick() {
        this.setState(state => ({
            showNew: !state.showNew
        }));
    }

    submitNewItem() {
        console.log(this.state.newPart);
        this.postData();
    }

    postData(){
        fetch('https://localhost:5001/api/todo', {
            method: 'post',
            body: JSON.stringify({
                "PartName": this.state.newPart.partName,
                "PartNumber": this.state.newPart.partNumber,
                "PartDescription": this.state.newPart.partDescription,
                "ManufacturerName": this.state.newPart.manufacturerName
            }),
            headers: {
                "Content-Type": "application/json"
              }
          })
            .then(()=>{this.retrieveData();this.setState(state=>({showNew: false}))});
        
          
    }
    

    render() {
        const showNew = this.state.showNew;
        return (
            <div className="PartList">

                <Fab color="secondary" aria-label="Add" className="add-button" onClick={this.newItemClick}>
                    {
                        showNew ?
                            (
                                <CancelIcon />
                            ) :
                            (
                                <AddIcon />
                            )

                    }
                </Fab>


                {
                    //This seems like not the way to do this, 
                    //But it works for now
                    showNew ?
                        (
                            <form className="new-part" noValidate autoComplete="off">
                                <h3>New Part Entry</h3>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-number" >Part #</InputLabel>
                                    <Input id="partNumber" aria-describedby="my-helper-text" onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-name">Part Name</InputLabel>
                                    <Input id="partName" aria-describedby="my-helper-text"  onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-description">Part Description</InputLabel>
                                    <Input id="partDescription" aria-describedby="my-helper-text"  onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="manufacturer-name">Manufacturer Name</InputLabel>
                                    <Input id="manufacturerName" aria-describedby="my-helper-text" onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl >
                                <Button variant="contained" color="primary" onClick={this.submitNewItem} className="button-save">
                                    <SaveIcon />
                                </Button>
                                </FormControl>
                            </form>
                        ) : (
                            <ol>
                                {this.state.parts.map(part =>
                                    <PartForm part={part} key={part.id} deleteCallback={this.retrieveData}/>
                                )}

                            </ol>
                        )
                }
            </div>

        );
    }
}


export default PartList;
