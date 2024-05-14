
export type UserModel = {
    userName: string;
    userProgress: number;
}

interface UserProps {
    user: UserModel;
}

function ProgressBar(props: UserProps) {
    return (
        <>{props.user.userProgress ?
            <progress id="in-progress" value={props.user.userProgress} max="100" />
            : <progress id="out-progress" value="0" max="100" />
        }
        </>
    )
}

export default ProgressBar