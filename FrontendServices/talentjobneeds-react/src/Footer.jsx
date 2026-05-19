 const Footer = () => {
    var visitTime = Date.now();
    return(
        <div className="footer">
            © All copy Rights are reserved... {visitTime} 
        </div>
    )
}

export {Footer}; // named export