import React, { Component } from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import './PartForm.css';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Fab from '@material-ui/core/Fab';
import EditIcon from '@material-ui/icons/Edit'
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import Input from '@material-ui/core/Input';
import FormHelperText from '@material-ui/core/FormHelperText';
import CancelIcon from '@material-ui/icons/Cancel';
import SaveIcon from '@material-ui/icons/Save';
import DeleteIcon from '@material-ui/icons/Delete';



class PartForm extends Component {

  constructor(props) {
    //super(props) when you want to use props in the constructor
    //Doing useful stuff like setting state
    super(props);
    this.state = {
      part: props.part,
      editing: false
    };

    //This makes it so you can use the 'this' keyword in the click method
    this.editToggle = this.editToggle.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.deleteData = this.deleteData.bind(this);
    this.saveChanges = this.saveChanges.bind(this);
  }

  deleteData(){
    fetch(`https://localhost:5001/api/todo/${this.state.part.id}`, {
        method: 'delete'
    }).then(()=>{
        this.props.deleteCallback();
        })
}

  handleChange(event) {

    const target = event.target;
    const value = target.value;
    const name = target.id;
    let part = this.state.part;
    part[name] = value;
    this.setState({
      part: part
    });
  }

  editToggle() {
    this.setState(state => ({
      editing: !state.editing
    }));
  }

  saveChanges(){
    fetch('https://localhost:5001/api/todo/', {
        method: 'put',
        body: JSON.stringify(this.state.part),
        headers: {
          "Content-Type": "application/json"
        }
    }).then(()=>{
        this.props.deleteCallback();
        this.editToggle();
        })
  }

  render() {
    const part = this.state.part;
    const editing = this.state.editing;
    return (

      <Card className="card">
        {editing ?
          (<CardContent>
             <form  noValidate autoComplete="off">
                                <h3>Edit Part Entry</h3>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-number" >Part #</InputLabel>
                                    <Input id="partNumber" aria-describedby="my-helper-text" value={part.partNumber} onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-name">Part Name</InputLabel>
                                    <Input id="partName" aria-describedby="my-helper-text" value={part.partName} onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="part-description">Part Description</InputLabel>
                                    <Input id="partDescription" aria-describedby="my-helper-text" value={part.partDescription} onChange={this.handleChange}/>
                                </FormControl>
                                <FormControl fullWidth={true}>
                                    <InputLabel htmlFor="manufacturer-name">Manufacturer Name</InputLabel>
                                    <Input id="manufacturerName" aria-describedby="my-helper-text" value={part.manufacturerName} onChange={this.handleChange}/>
                                </FormControl>
                            </form>
          </CardContent>
          )
          :
          (<CardContent>
            <Typography className="card-title">
              {part.partNumber}
            </Typography>

            <Typography color="textSecondary">
              {part.partName}
            </Typography>
            <Typography variant="body2" component="p">
              {part.partDescription}
            </Typography>
            <Typography color="textSecondary" className="manName">
              Manufactured By: {part.manufacturerName}
            </Typography>
          </CardContent>
          )}



        {
          editing ?
            (
              <CardActions>
                <Button variant="contained" color="primary" onClick={this.saveChanges}>
                  <SaveIcon></SaveIcon>
                </Button>
                <Button variant="contained" color="primary" onClick={this.editToggle}>
                  <CancelIcon></CancelIcon>
                </Button>
              </CardActions>
            )
            :
            (
              <CardActions>
                <Button variant="contained" color="primary" onClick={this.editToggle}>
                  <EditIcon></EditIcon>
                </Button>
                <Button variant="contained" color="primary" onClick={this.deleteData}>
                  <DeleteIcon></DeleteIcon>
                </Button>
              </CardActions>)
        }
          
      </Card >
    );
  }
}

export default PartForm;
