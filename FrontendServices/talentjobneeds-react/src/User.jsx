import React, { useContext, useEffect, useState } from "react";

const User = (props) => {
    const [username, setUserName] = useState('');
    const [location, setLocation] = useState('');
    const [html_url, setHtmlUrl] = useState('');

    const loaddata = async () => {
        const data = await fetch("https://api.github.com/users/" + props.loginName);
        const json = await data.json();
        //console.log(json);
        if (json.name != null) {
            setUserName(json.name);
            setLocation(json.location);
            setHtmlUrl(json.html_url)
        }
    }

    useEffect(() => {
  console.log("Runs only once");
  loaddata();
}, [props.loginName]);


    return (
        <div className="text-left border border-black bg-slate-200 my-3">
            <h2 className="mx-10 my-3 px-10">Name: {username}</h2>
            <h3 className="mx-10 my-3 px-10">Location: {location}</h3>
            <h3 className="mx-10 my-3 px-10">Linkedin: <a className="text-blue-700 underline hover:text-blue-900"> www.linkedin.com/in/garikipatisudhakararao</a></h3>
            <h3 className="mx-10 my-3 px-10">Github: <a className="text-blue-700 underline hover:text-blue-900" href={html_url}>{html_url}</a></h3>
        </div>
    )
}
export default User;