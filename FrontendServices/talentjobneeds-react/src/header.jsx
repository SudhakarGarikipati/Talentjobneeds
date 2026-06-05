import logo from './assets/Jobneeds.png';
import { useState, useContext, useEffect } from "react";
import { Link } from "react-router-dom";
import useOnlineStatus from "./useOnlineStatus";
import UserContext from './utilities/UserContext';

const Header = () => {
    const [signIn, setSingnIn] = useState("LogIn");
    const {loggedInUser} = useContext(UserContext);
    const isOnline = useOnlineStatus();

    useEffect(()=>{
        console.log(loggedInUser);
        if (loggedInUser === "Guest User")
        {
            setSingnIn("LogIn");
        }
        else{
            setSingnIn("LogOut");
        }
    },[loggedInUser]);

    return (
        <div className="justify-between flex border border-solid border-black ">
            <div className="flex" >
            <img className="size-16"  src={logo}></img>
            <p className="py-5 mx-10 font-bold">{loggedInUser}</p>
            </div>
            <div className="">
                <ul className="flex my-6 font-serif" >
                    <li className='mx-5'>{isOnline ? 'Online': 'Offline'}</li>
                    <li className='mx-5'><Link to="./">Home</Link></li>
                    <li className='mx-5'><Link to="./AboutUs">About Us</Link></li>
                    <li className='mx-5'><Link to="./ContactUs">Contact Us</Link></li>
                    <li className='mx-5'><Link to="./SignUp">Sign Up</Link></li>
                    <li className='mx-5'><Link to="./Employers">Employers</Link></li>
                    <li className='mx-5'><Link to={"./" + signIn}>{signIn}</Link></li>
                </ul>
            </div>
        </div>
    )
}
export default Header;