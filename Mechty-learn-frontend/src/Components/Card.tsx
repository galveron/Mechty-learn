export interface CardTitle {
    title: string
}

function Card(props: CardTitle) {
    return (
        <>
            <div className="card">
                <div className="card3d">kép</div>
                <h5 id="card-label">{props.title}</h5>
            </div>
        </>)
}

export default Card;