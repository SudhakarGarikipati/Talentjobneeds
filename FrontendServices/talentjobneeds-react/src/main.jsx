import { lazy, StrictMode, Suspense } from 'react'
import { createRoot } from 'react-dom/client'
import Error from './Error.jsx'
import { ContactUs } from './ContactUs.jsx'
import { Login } from './Login.jsx'
import { Logout } from './Logout.jsx'
import { SignUp } from './SignUp.jsx'
import { AboutUs } from './AboutUs.jsx'
import App from './App.jsx'
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import Home from './Home.jsx'
import Search from './Search.jsx'
import { Details } from './details.jsx'
//import Employers from './employers.jsx'

//Chunkin or Code Splitting or Dynamic Bundling or Lazy Loading or ondemand loading
const Employers = lazy(()=> import('./employers.jsx'));

const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "/", element: <Home />, errorElement: <Error /> },
      //{ path: "/AboutUs", element: <Suspense fallback={<h1>Loading…</h1>}><AboutUs /></Suspense>, errorElement: <Error /> },
      { path: "/AboutUs", element: <AboutUs />, errorElement: <Error /> },
      { path: "/ContactUs", element: <ContactUs />, errorElement: <Error /> },
      { path: "/SignUp", element: <SignUp />, errorElement: <Error /> },
      { path: "/Login", element: <Login />, errorElement: <Error /> },
      { path: "/LogOut", element: <Logout />, errorElement: <Error /> },
      {path: "/Employers",element:<Suspense fallback={"<p>Page is loading...!</p>"}><Employers/></Suspense>, errorElement: <Error />},
      { path: "/Search", element: <Search />, errorElement: <Error /> },
      { path: "/Details/:jobid", element: <Details />, errorElement: <Error /> }
    ],
    errorElement: <Error />
  }
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={appRouter} />
  </StrictMode>
);
