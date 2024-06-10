import * as React from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Typography from '@mui/material/Typography';
import CardContent from '@mui/material/CardContent';
import Center from './Center';
import "./login.css"
import UseForm from '../hooks/UseForm';
import { ENDPOINTS, createApiEndPoint } from '../api';
import useStateContext from '../hooks/useStateContext';
import {useNavigate} from 'react-router'
import { useEffect } from 'react';

const getFreshModel = () => ({
  name:'',
  email:''
})

export default function BasicTextFields() {

  const {context,setContext,resetContext} = useStateContext();
    const navigate = useNavigate()

  
const {
  values,
  SetValues,
  errors,
  SetErrors,
  handleInputChange
} = UseForm(getFreshModel)

useEffect(() => {
  resetContext()
}, [])

  
  const login = e=> {
    e.preventDefault()
    if(validate())
    createApiEndPoint(ENDPOINTS.participant)
    .post(values)
    .then(res => {
      setContext({participantId: res.data.participantId})
      navigate('/quize')
    } )
    .catch(err => console.log(err))
    
     
  }

  const validate = ()=>{
    let temp = {}
    temp.email = (/\S+@\S+\.\S+/).test(values.email)? "" : "Email is not valid."
    temp.name = values.name !="" ? "" : "this field is required"
    SetErrors(temp)
    return Object.values(temp).every(x => x == "")


  }

  return (

    <Center className='gocenter'>
      

      <Card sx={{width:"400px"}} >
        <CardContent sx={{textAlign:"center"}}>


        {context.participantId}{/*در صورتی که مقدار از قبل وارد شده آیدی آن توسط این دستور نمایش داده میشود */}



      <Typography variant='h3' sx={{my:3}}>
        Quize App
        </Typography>

    <Box  sx={{
        '& .MuiTextField-root': {
            m:1,
            width:'90%'
        }
      
    }}>

    <form noValidate  autoComplete="on" onSubmit={login}>

      <TextField 
        label="name"
        name='name'
        value={values.name}
         onChange={handleInputChange}
        variant="outlined"
        {...(errors.name && {error:true, helperText:errors.name})}
        />


      <TextField
         label="Email"
         name='email' 
         value={values.Email}
         onChange={handleInputChange}
         variant="outlined" 
         {...(errors.email && {error:true, helperText:errors.email})}
         />
     

        <Button 
        type='submit'
        variant="contained"
        size="large"
        sx={{width:'90%'}}
        >
        start
        </Button>
        
       

    </form>
    </Box>
        </CardContent>
      </Card>

    </Center>

  );
}