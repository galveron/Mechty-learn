

export interface UserProgress {
    progress?: number;
}

function ProgressBar(props: UserProgress) {
    return (
        <>{props.progress ?
            <progress id="in-progress" value={props.progress} max="100" />
            : <progress id="out-progress" value="0" max="100" />
        }
        </>
    )
}

export default ProgressBar