import { useState, useEffect } from "react";

const useOnlineStatus = () =>{
    
    const [isOnline,setIsOnline] = useState(true);

    //check online status
    useEffect(()=>{
        addEventListener("online", (event) => {
        setIsOnline(true);
     })
   
     addEventListener("offline", (event) => { 
        setIsOnline(false)
     })
    },[])
    // return boolean of online status
    return isOnline;
}

export default useOnlineStatus;