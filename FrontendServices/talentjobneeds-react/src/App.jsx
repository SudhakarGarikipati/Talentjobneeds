import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import Header from './header'
import {Footer} from './Footer'
import Body from './Body'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
     <Header/>
     <Body/>
     <Footer/>
    </div>
  )
}

export default App
