import { useState, useContext, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import UserContext from "./utilities/UserContext";

const Search = () => {

    const { loggedInUser } = useContext(UserContext);
    const navigate = useNavigate();

    useEffect(() => {
        if (loggedInUser === "Guest User") {
        navigate("/Login")
        }
    }, [loggedInUser]);

    const [searchText, setSearchText] = useState("");

    const searchHandler = () => {
        console.log(searchText);
    }

    const textChangeHandler = (args) => {
        setSearchText(args.target.value);
    }

    console.log("body rendered...")

    return (
        <div>
            <div className="text-center">
                <input type="text" className="py-2 m-5 border-blue-400 px-2" value={searchText} onChange={textChangeHandler}></input>
                <button className="cursor-pointer p-2 m-4 border text-white bg-black font-medium rounded-lg" onClick={searchHandler}>Search</button>
            </div>
        </div>
    )
}
 
export default Search;