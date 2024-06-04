import { useEffect, useState } from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import Home from './Pages/Home'
import Profile from './Pages/Profile'
import Layout, { User } from './Layout'
import './scss/index.scss'

console.log("url: " + process.env.RENDER_BACKEND_URL)

function App() {
  const [user, setUser] = useState<User>()
  const [userId, setUserId] = useState<string>("")

  async function fetchUser(id: string) {
    let url = `/api/Adults/GetAdultById?id=${id}`

    try {
      const res = await fetch(url,
        {
          method: "GET",
          headers: { 'Content-type': 'application/json' }
        })

      if (!res.ok) {
        throw new Error(`Failed to fetch: ${res.status} ${res.statusText}`);
      }

      const data = await res.json()

      const newUser: User = {
        userEmail: data.email,
        userName: data.userName,
        userId: id,
        userProgress: 0
      }

      return newUser
    }
    catch (error) {
      console.error("Error fetching user:", error)
      throw Error("Faild to fetch")
    }
  }

  useEffect(() => {
    setUserId("d54bb95a-97f8-4852-bd23-b10c32b0a75a")
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
  return <RouterProvider router={router} />
}

export default App
