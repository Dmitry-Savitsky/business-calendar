import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Table } from 'react-bootstrap';

// Пример данных для отзывов
const reviewsData = [
    {
        idReview: 1,
        idOrder: 101,
        ClientName: "John Doe",
        ServiceName: "floor cleaning",
        ReviewText: "Great service, very thorough!",
        ReviewRating: "★★★★★"
    }
];

const ReviewsPage = () => {
    const [reviews, setReviews] = useState([]);

    useEffect(() => {
        // Здесь вы можете сделать запрос к API для получения данных отзывов
        // Пример: fetch('/api/reviews').then(response => response.json()).then(data => setReviews(data));
        
        // Используем пример данных для отзывов
        setReviews(reviewsData);
    }, []);

    return (
        <Container className="mt-5">
            <Row className="mb-4">
                <Col>
                    <h1>Отзывы клиентов</h1>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>ID Отзыва</th>
                                <th>ID Заказа</th>
                                <th>Имя клиента</th>
                                <th>Название услуги</th>
                                <th>Текст отзыва</th>
                                <th>Рейтинг</th>
                            </tr>
                        </thead>
                        <tbody>
                            {reviews.map(review => (
                                <tr key={review.idReview}>
                                    <td>{review.idReview}</td>
                                    <td>{review.idOrder}</td>
                                    <td>{review.ClientName}</td>
                                    <td>{review.ServiceName}</td>
                                    <td>{review.ReviewText}</td>
                                    <td>{review.ReviewRating}</td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </Col>
            </Row>
        </Container>
    );
};

export default ReviewsPage;