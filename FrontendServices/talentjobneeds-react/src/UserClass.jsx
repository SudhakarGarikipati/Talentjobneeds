import React from "react";


class UserClass extends React.Component{
    constructor(props){
        super(props);
        //console.log(props);
        this.state = {
           username : "",
           location :"",
           html_url:""

        }
    }

    async componentDidMount(){
        const data = await fetch("https://api.github.com/users/"+ this.props.loginName);
        const json  = await data.json();
        console.log(json);
        this.setState({
            username:json.name,
            location:json.location,
            html_url:json.html_url
        });
    }

    componentDidUpdate(){
        // Invoked on update state from response for apicall or any user action
        //console.log("Update component called.")
    }

    componentWillUnmount(){
        // Invoked whem we move to other page.
        // No render here

    }

    render(){
        return(
            <div className="text-left border border-black bg-slate-200 my-3">
            <h2 className="mx-10 my-3 px-10">Name: {this.state.username}</h2>
            <h3 className="mx-10 my-3 px-10">Location: {this.state.location}</h3>
            <h3 className="mx-10 my-3 px-10">Linkedin: <a className="text-blue-700 underline hover:text-blue-900"> www.linkedin.com/in/garikipatisudhakararao</a></h3>
            <h3 className="mx-10 my-3 px-10">Github: <a className="text-blue-700 underline hover:text-blue-900" href={this.state.html_url}>{this.state.html_url}</a></h3>
        </div>
        )
    }
}
export default UserClass;