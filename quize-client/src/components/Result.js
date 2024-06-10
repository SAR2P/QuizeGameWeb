import React, { useEffect } from 'react'
import useStateContext from '../hooks/useStateContext'
import { ENDPOINTS, createApiEndPoint } from '../api'

export default function Result() {

const {context,setContext} = useStateContext()

  useEffect( () => {
   const ids = context.selectedOptions.map(x => x.qnId)

    createApiEndPoint(ENDPOINTS.getAnswers).post(ids).then(res => {
      console.log(res.data)
      
      
    })
    .catch(err => console.log(err))
  },[])


  return (
    <div>Result</div>
  )
}
