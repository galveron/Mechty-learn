export type User = {
    userName?: string,
    userId?: string,
    userEmail?: string,
    userProgress?: number
}


function Profile({ userName, userEmail }: User) {
    return (
        <>
            <div className="profile">
                <aside className="side-profile">
                    <div className="side-3d">3d element</div>
                    <div className="side-div"><button className="side-btn">Settings</button></div>
                    <div className="side-div"><button className="side-btn">Courses</button></div>
                    <div className="side-div"><button className="side-btn">Help</button></div>
                    <div className="side-div"><button className="side-btn">Contact</button></div>
                </aside>
                <section className="section-profile">
                    <h1 id="section-title">Your profile</h1>
                    <form id="profile-form">
                        <label htmlFor="change-username-input">User name:</label>
                        <input type="text" id="change-username-input" defaultValue={userName} />
                        <label htmlFor="change-email-input">Email:</label>
                        <input type="text" id="change-email-input" defaultValue={userEmail} />
                        <div id="change-div"><button id="change-btn" type="submit">Change</button></div>
                    </form>
                    <div className="change-password">
                        <label htmlFor="change-password-div">Password:</label>
                        <div id="change-password-div"><button id="change-password-btn" type="submit">Change password</button></div>
                    </div>
                </section>
            </div>
        </>
    )
}

export default Profile
