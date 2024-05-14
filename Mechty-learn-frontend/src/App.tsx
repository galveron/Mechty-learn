import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Home from './Pages/Home'
import Layout from './Layout'
import './scss/index.scss'

function App() {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <Layout />,
      //errorElement: <ErrorPage />,
      children: [
        {
          path: '/',
          element: <Home />
        }
      ]
    }
  ])
  return <RouterProvider router={router} />;
}

export default App
