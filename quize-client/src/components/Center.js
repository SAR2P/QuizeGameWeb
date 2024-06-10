import React from 'react'
import Grid from '@mui/material/Card';
import "./center.css"

export default function Center(props) {
  return (
    <Grid 
        
         container="true"
         direction="column"
        //  justifycontent="center"
         
        sx={{minHeight:"100vh"}}
        >

            <Grid item='true'  >
                {props.children}
            </Grid>

    
    </Grid>

    )
}
