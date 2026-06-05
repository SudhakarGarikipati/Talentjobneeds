import React, { useRef, useContext, useEffect } from 'react'
import { useNavigate } from 'react-router-dom';
import UserContext from './utilities/UserContext';

export const Login = () => {

  var {loginUser, setUser} = useContext(UserContext);

  const navigate = useNavigate();
  const luser = useRef();
  const pwd = useRef();

  const loginhandler = async () => {
    const data = await fetch("https://localhost:7000/jobneeds/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        "Email": luser.current.value ,
        "Password":  pwd.current.value 
      })
    });
    const json = await data.json();
    console.log(json);
    if(data.status === 200)
    {
      setUser(json.firstName + ' ' + json.lastName)
      navigate("/Search")
    }
  }

  return (
    <div className='flex justify-center'>
      <table className='m-10'>
        <tbody>
        <tr>
          <td>User Id/Email:</td>
          <td><input type='text' ref={luser} className='mx-8 my-3 h-8 px-2' /></td>
        </tr>
        <tr>
          <td>Password:</td>
          <td><input type='text' ref={pwd} className='mx-8 my-3 h-8' /> </td>
        </tr>
        <tr>
          <td></td>
          <td className='text-center'>
            <button className='bg-gray-300 border px-8 py-2' onClick={loginhandler}>Login</button>
          </td>
        </tr>
        </tbody>
      </table>
    </div>
  )
}

