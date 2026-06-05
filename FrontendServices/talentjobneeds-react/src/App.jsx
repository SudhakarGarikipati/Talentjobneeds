import { useContext, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
//import './App.css'
import Header from './header'
import { Footer } from './Footer'
import Body from './Search'
import { createBrowserRouter, RouterProvider, Outlet } from 'react-router-dom'
import UserContext from './utilities/UserContext'

function App() {

  const {loggedInUser} = useContext(UserContext);

  const [loginUser, setUser] = useState(loggedInUser);

  return (
    <div className="min-h-screen flex flex-col bg-neutral-100">
    <UserContext.Provider value={ {loggedInUser: loginUser, setUser}}>
    <Header />
    <main className="flex-1">
        <Outlet />
    </main>
    </UserContext.Provider>
    <Footer />
</div>
  )
}

export default App
