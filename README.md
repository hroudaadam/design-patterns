# Design patterns
this project contains examples of design patterns to help me understand them better

## Creational

### Abstract factory
provides an interface for creating families of related or dependent objects without specifying their concrete classes

### Factory
creates object without exposing the creation logic to the client and refers to newly created object using a common interface

### Builder
separates the construction of a complex object from its representation so that the same construction process can create different representations

### Singleton
restricts the instantiation of a class to one instance

### Prototype
specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype

### Object pool
set of initialized objects kept ready to use

### Dependency injection
moves the creation and binding of the dependent objects outside of the class that depends on them

### Lazy
delaying he creation of an object until the first time it is needed

## Structural

### Adapter (Wrapper)
converts the interface of a class into another interface clients expect

### Decorator
allows behavior to be added to an individual object, dynamically, without affecting the behavior of other objects from the same class

### Proxy
controls access to the original object, allowing you to perform something either before or after the request gets through to the original object

### Composite
lets clients treat objects and compositions in a tree uniformly

### Bridge
devides one large inheritance hierarchy into two hierarachies

### Facade
provides a unified interface to a set of interfaces in a subsystem

### Flyweight
lets many objects use common data to save memory

## Behavioural

### Observer
defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically

### State
allows an object to alter its behavior when its internal state changes

### Strategy
enables selecting an algorithm at runtime

### Mediator
restricts direct communications between the objects and forces them to collaborate only via a mediator object

### Memento
lets clients save and restore the previous state of an object without revealing the details of its implementation

### Command
turns a request into a stand-alone object that contains all information about the request

### Template method
defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps

### Visitor
lets you separate algorithms from the objects on which they operate

### Iterator
lets clients traverse elements of a collection without exposing its underlying representation

### Chain of responsibility
lets requests to passed along a chain of handlers

### Interpreter
specifies how to evaluate sentences in a language