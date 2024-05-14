import Card, { CardTitle } from '../Components/Card'
import Article, { ArticleContent } from '../Components/Article'


function Home() {
    const title1: CardTitle = {
        title: "Lectures"
    }

    const title2: CardTitle = {
        title: "How does it work"
    }

    const title3: CardTitle = {
        title: "About us"
    }

    const title4: CardTitle = {
        title: "Connect"
    }

    const article1: ArticleContent = {
        title: "A lot of text about something interesting",
        text: "Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text.",
        align: true
    }

    const article2: ArticleContent = {
        title: "This is interesting too",
        text: "Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text.",
        align: false
    }

    const article3: ArticleContent = {
        title: "And that is the best",
        text: "Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text.",
        align: true
    }

    const article4: ArticleContent = {
        title: "Or this",
        text: "Longlong text.  Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text. Longlong text.",
        align: false
    }

    return (
        <>
            <section className='home-section'>
                <Card title={title1.title} />
                <Card title={title2.title} />
                <Card title={title3.title} />
                <Card title={title4.title} />
            </section>
            <article className='home-article'>
                <Article title={article1.title} text={article1.text} align={article1.align} />
                <Article title={article2.title} text={article2.text} align={article2.align} />
                <Article title={article3.title} text={article3.text} align={article3.align} />
                <Article title={article4.title} text={article4.text} align={article4.align} />
            </article>
        </>
    )
}
export default Home;