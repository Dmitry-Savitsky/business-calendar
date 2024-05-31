import React from 'react';
import { Container, Row, Col, Accordion } from 'react-bootstrap';

const FAQPage = () => {
    return (
        <Container className="mt-5">
            <Row className="mb-4">
                <Col>
                    <h1>Часто задаваемые вопросы (FAQ)</h1>
                    <p>Здесь вы найдете ответы на самые часто задаваемые вопросы о нашем сервисе.</p>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Accordion>
                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Как зарегистрироваться в ServiceManager?</Accordion.Header>
                            <Accordion.Body>
                                Для регистрации в ServiceManager перейдите на страницу регистрации, заполните необходимые поля и следуйте инструкциям. После регистрации вы сможете войти в систему и начать использовать наш сервис.
                            </Accordion.Body>
                        </Accordion.Item>
                        <Accordion.Item eventKey="1">
                            <Accordion.Header>Как добавить новую услугу?</Accordion.Header>
                            <Accordion.Body>
                                Чтобы добавить новую услугу, перейдите в раздел "Управление услугами", нажмите кнопку "Добавить услугу" и заполните форму. После сохранения услуга станет доступной для назначения исполнителям и заказов.
                            </Accordion.Body>
                        </Accordion.Item>
                        <Accordion.Item eventKey="2">
                            <Accordion.Header>Как назначить исполнителя на заказ?</Accordion.Header>
                            <Accordion.Body>
                                Для назначения исполнителя на заказ перейдите в раздел "Управление заказами", выберите заказ и нажмите кнопку "Назначить исполнителя". Выберите исполнителя из списка и подтвердите назначение.
                            </Accordion.Body>
                        </Accordion.Item>
                        <Accordion.Item eventKey="3">
                            <Accordion.Header>Как просмотреть статистику заказов?</Accordion.Header>
                            <Accordion.Body>
                                Для просмотра статистики заказов перейдите в раздел "Анализ заказов". Выберите период времени и другие параметры для анализа. Система отобразит статистику, включая количество заказов, их статус и другие метрики.
                            </Accordion.Body>
                        </Accordion.Item>
                        <Accordion.Item eventKey="4">
                            <Accordion.Header>Как связаться с поддержкой?</Accordion.Header>
                            <Accordion.Body>
                                Если у вас возникли вопросы или проблемы, вы можете связаться с нашей поддержкой через форму обратной связи на сайте или по электронной почте support@servicemanager.com. Мы всегда готовы помочь вам.
                            </Accordion.Body>
                        </Accordion.Item>
                    </Accordion>
                </Col>
            </Row>
        </Container>
    );
};

export default FAQPage;