import { useEffect, useState } from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Home from './Pages/Home'
import Profile from './Pages/Profile'
import Layout, { User } from './Layout'
import './scss/index.scss'



function App() {
  const [user, setUser] = useState<User>();
  const [userId, setUserId] = useState<string>("");

  async function fetchUser(id: string) {
    let url = `/api/Adults/GetAdultById?id=${id}`
    const res = await fetch(url,
      {
        method: "GET",
        credentials: 'include',
        headers: { 'Content-type': 'application/json' }
      })
    if (res.status) {
      const data = await res.json()

      const newUser: User = {
        userEmail: data.email,
        userName: data.userName,
        userId: id,
        userProgress: 0
      }

      return newUser
    }
    throw Error("Faild to fetch")
  }

  useEffect(() => {
    setUserId("8a297dee-6540-43c4-bc93-ac3a189cc7dd")
  }, [])

  useEffect(() => {
    if (userId.length) {
      fetchUser(userId)
        .then(user => setUser(user))
    }
  }, [userId])

  const router = createBrowserRouter([
    {
      path: '/',
      element: <Layout
        userName={user?.userName}
        userId={user?.userId}
        userEmail={user?.userEmail}
        userProgress={user?.userProgress} />,
      //errorElement: <ErrorPage />,
      children: [
        {
          path: '/',
          element: <Home />
        },
        {
          path: '/home',
          element: <Home />
        },
        {
          path: '/profile',
          element: <Profile
            userName={user?.userName}
            userId={user?.userId}
            userEmail={user?.userEmail}
            userProgress={user?.userProgress} />
        }
      ]
    }
  ])
  return <RouterProvider router={router} />;
}

export default App
