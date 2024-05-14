import { Outlet } from "react-router-dom"
import './scss/layout/_layout.scss'
import Logo from './Components/Logo'
import Navbar, { UserName } from './Components/Navbar';
import ProgressBar, { UserModel } from "./Components/ProgressBar";

function Layout() {
    //let userName: string = "Senki";
    const user: UserModel = {
        userName: "senki",
        userProgress: 0
    }

    const name: UserName = {
        userName: ""
    }

    return (
        <>
            <header>
                <Logo />
                <nav>
                    <Navbar userName={name.userName} />
                    <ProgressBar user={user} />
                </nav>
            </header>
            <div className="outlet">
                <Outlet />
            </div>
        </>
    )
}

export default Layout;