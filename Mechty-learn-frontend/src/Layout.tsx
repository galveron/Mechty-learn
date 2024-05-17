import { Outlet } from "react-router-dom"
import './scss/layout/_layout.scss'
import Logo from './Components/Logo'
import Navbar, { UserName } from './Components/Navbar';
import ProgressBar, { UserProgress } from "./Components/ProgressBar";

export interface User {
    userName?: string,
    userId?: string,
    userEmail?: string,
    userProgress?: number
}

function Layout({ userName, userProgress }: User) {
    //let userName: string = "Senki";
    const progress: UserProgress = {
        progress: userProgress,
    }

    const name: UserName = {
        userName: userName
    }

    return (
        <>
            <header>
                <Logo />
                <nav>
                    <Navbar userName={name.userName} />
                    <ProgressBar progress={progress.progress} />
                </nav>
            </header>
            <div className="outlet">
                <Outlet />
            </div>
        </>
    )
}

export default Layout;