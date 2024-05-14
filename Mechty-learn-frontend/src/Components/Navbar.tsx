export interface UserName {
    userName: string;
}

function Navbar(props: UserName) {
    const userName = props.userName
    return (
        <>
            <section className="nav-section">
                {userName ?
                    <div id="user-name">Hello, {userName}!</div>
                    : <>
                        <button className="register-btn">Register</button>
                        <button className="signin-btn">Sign in</button>
                    </>
                }
            </section>
        </>
    )
}

export default Navbar