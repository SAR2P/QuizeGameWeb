import React from 'react'
import { useState } from "react";

export default function UseForm(getFreshModelObject) {

    const [values,SetValues] = useState(getFreshModelObject());
    const [errors,SetErrors]= useState({})

    const handleInputChange = e => {
        const {name, value} = e.target
        SetValues({
            ...values,
            [name]:value
        })
    }

    return{
        values,
        SetValues,
        errors,
        SetErrors,
        handleInputChange
    }
}





