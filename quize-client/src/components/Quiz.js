import React, { useContext, useEffect, useState } from 'react'
import useStateContext, { stateContext } from '../hooks/useStateContext'
import { ENDPOINTS, createApiEndPoint } from '../api'
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import  List  from '@mui/material/List';
import ListItemButton from "@mui/material/ListItemButton"
import CardHeader from "@mui/material/CardHeader"
import { GetFormatedTime } from '../helper';
import Box from '@mui/material/Box';
import LinearProgress from '@mui/material/LinearProgress';
import CardMedia from '@mui/material/CardMedia'
import {BASE_URL}from "../api/index"
import { useNavigate } from 'react-router'

export default function Quiz() {
  
  const [qns,setQns]= useState([])
  const [qnIndex,setQnIndex] = useState(0)
  const [timeTaken,setTimeTaken] = useState(0)
  const {context,setContext} = useStateContext()
  const navigate = useNavigate()
let timer;



  const startTimer = () => {
      timer = setInterval( () => {
      setTimeTaken(prev => prev + 1)
    },[1000])
  }

  useEffect(()=>{
      setContext({
        timeTaken:0,
        selectedOptions:[]
      })

      createApiEndPoint(ENDPOINTS.question)
      .fetch()
      .then(res=>{
       setQns(res.data)
       startTimer()
      })
       .catch(err => {console.log(err);})
      
       return () => {clearInterval(timer)}

  },[])

  const updateAnswer = (QnId,optionIdx) => {
    const temp = [...context.selectedOptions]
     temp.push({
      QnId:QnId,
      selected:optionIdx
    })

    if(qnIndex < 4){
      setContext({selectedOptions: [...temp]})
      setQnIndex(qnIndex +1)
    }
    else{
      setContext({selectedOptions: [...temp], timeTaken:timeTaken })
      navigate("/result")

    }

  } 

  return (
    qns.length != 0
     ? <Card 
     sx={{maxWidth:640,mx:'auto',mt:5,
         '& .muiCardHeader-action':{m:0,alignSelf:'center'} }} 
     >

        <CardHeader
         title={'Question ' + (qnIndex + 1) + ' of 5'}
         action={<Typography>{GetFormatedTime(timeTaken)}</Typography>}
           />

            <Box>
            <LinearProgress variant="determinate" value={(qnIndex + 1)*100/5} />
            </Box>
                  {qns[qnIndex].imageName != null
                    ? <CardMedia
                      component={"img"}
                      image = {BASE_URL + 'images/' + qns[qnIndex].imageName}
                      sx={{width:'auto',m:'10px auto'}}
                    />
                    : null
                  }
       
      
          <CardContent>
              <Typography variant='h6'>
                {qns[qnIndex].qnInWords}
              </Typography>

              <List>

                  
                      {qns[qnIndex].options.map((item, idx) => 
                        <ListItemButton key={idx} 
                          disableRipple
                          onClick={()=>updateAnswer(qns[qnIndex].QnId ,idx )}
                         >
                            <div>
                             <b> {String.fromCharCode(65 + idx) + " . " }</b> {item}
                            </div>
                        </ListItemButton>
                      )}
              </List>

          </CardContent>
      </Card> :null
  )
}
