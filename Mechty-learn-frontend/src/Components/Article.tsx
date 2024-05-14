export interface ArticleContent {
    title: string,
    text: string,
    align: boolean
}


function Article({ title, text, align }: ArticleContent) {
    var colors = ['#ff40bd', '#9e5aff', '#2c66ff'];
    var randomcolor = colors[(Math.floor(
        Math.random() * colors.length))];

    return (
        <>
            {align ?
                <div className="article-left">
                    <div style={{ backgroundColor: randomcolor }} className="article3d-left" ></div>
                    <div className="article-description-left">
                        <h5 className="article-title-left">{title}</h5>
                        <div className="article-text-left">{text}</div>
                    </div>
                </div>
                : <div className="article-right">
                    <div className="article-description-right">
                        <h5 className="article-title-right">{title}</h5>
                        <div className="article-text-right">{text}</div>
                    </div>
                    <div style={{ backgroundColor: randomcolor }} className="article3d-right"></div>
                </div>
            }

        </>
    )
}

export default Article;