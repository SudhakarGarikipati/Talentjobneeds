 const Footer = () => {
    var visitTime = Date.now();
    return(
        <div className="text-center">
             <hr className="border-t border-gray-400 my-2 w-full" />
            
            © All copy Rights are reserved... {visitTime} 
        </div>
    )
}

export {Footer}; // named export