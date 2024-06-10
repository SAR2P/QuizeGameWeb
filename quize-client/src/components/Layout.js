import React from 'react'
import {AppBar, Toolbar, Typography, Container, Button} from '@mui/material'
import useStateContext from '../hooks/useStateContext'
import { Outlet, useNavigate } from 'react-router'

export default function Layout() {
    const {resetContext} = useStateContext()
    const navigate = useNavigate()

    const logout = () => {
        resetContext()
        navigate("/")
    }


  return (
    <>
      <AppBar
             position='sticky' >
            <Toolbar sx={{width:640,m:'auto'}}>
               <Typography 
                   variant='h4'
                   align='center'
                   sx={{flexGrow:1}}
                 >
                   Quize App
               </Typography>

               <Button
                onClick={logout} >
                LogOut
               </Button>
         </Toolbar>
      </AppBar>
     
      <Container>

      </Container>
    <Outlet />
    </>

  )
}
