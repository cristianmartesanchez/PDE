import React, { useState, useEffect, useMemo } from 'react';
import axios from 'axios';

const AppContext = React.createContext();

function stringDateToObject(value)
{
    let arr1 = value.split("T");
    let arr2 = arr1[0].split("-");
    let arr3 = arr1[1].split(":");
    return new Date(arr2[0], arr2[1]-1, arr2[2], arr3[0]-4, arr3[1], arr3[2].replace('Z', ''));
}

export function AppProvider(props){
    const [usuario, setUsuario] = useState(null);
    const [token, setToken] = useState(null);
    const [expirationDate, setExpirationDate] = useState(null);
    const url = "http://192.168.137.1:5295/api/";

    function logIn(username, password)
    {
	let _url = url+"authenticate/login";
	axios.post(_url, {username, password})
	.then(resp => {
	    setUsuario(JSON.parse(resp.data.user));
	    setToken(resp.data.token);
	    setExpirationDate(stringDateToObject(resp.data.expiration));
	})
	.catch(err => console.log(error));
    }

    function logOut()
    {
	setUsuario(null);
	setToken(null);
	setExpirationDate(null);
    }

    useEffect(()=>{
	if(expirationDate === new Date()) logOut();
    });

    const value = useMemo(() =>
	{
	    return({
		usuario,
		logIn,
		logOut
	    })
	}, [usuario, token, expirationDate]);

    return <AppContext.Provider value={value} {...props} />
}

export function useApp(){
    const context = React.useContext(AppContext);
    if(!context)
	throw new Error("<<useApp>> debe estar dentro del proveedor <<AppContext>>")
    return context;
}

