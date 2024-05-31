import React from 'react';
import { Container, Row, Col, Button, Card } from 'react-bootstrap';

const MainPage = () => {
    return (
        <Container className="mt-5">
            <Row className="mb-4">
                <Col>
                    <h1>Добро пожаловать в ServiceManager</h1>
                    <p>ServiceManager - это сервис, предоставляющий компаниям управление своими услугами, исполнителями и приходящими заказами. Наша цель - помочь вам эффективно управлять бизнесом и предоставлять качественные услуги вашим клиентам.</p>
                </Col>
            </Row>
            <Row className="mb-4">
                <Col>
                    <h2>Наши преимущества</h2>
                </Col>
            </Row>
            <Row>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Управление услугами</Card.Title>
                            <Card.Text>
                                Создавайте, редактируйте и удаляйте услуги, управляя их доступностью и характеристиками.
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </Col>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Управление исполнителями</Card.Title>
                            <Card.Text>
                                Назначайте исполнителей на заказы, отслеживайте их прогресс и оценивайте качество выполнения работ.
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </Col>
                <Col md={4}>
                    <Card>
                        <Card.Body>
                            <Card.Title>Управление заказами</Card.Title>
                            <Card.Text>
                                Принимайте заказы от клиентов, распределяйте их между исполнителями и контролируйте выполнение.
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
            <Row className="mt-4">
                <Col>
                    <Button variant="primary" size="lg">Начать работу</Button>
                </Col>
            </Row>
        </Container>
    );
};

export default MainPage;