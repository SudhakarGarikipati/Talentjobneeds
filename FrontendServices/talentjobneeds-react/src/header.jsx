import "./header.css"
import logo from './assets/Jobneeds.png';


const Header = () => {
    return (
        <div className="header">
            <div className="logo-conatainer">
            <img className="logo"  className="logo" src={logo}></img>
            </div>
            <div className="nav-items">
                <ul className="menu">
                    <li>Home</li>
                    <li>Contact Us</li>
                    <li>Sign Up</li>
                    <li>Login</li>
                </ul>
            </div>
        </div>
    )
}
export default Header;