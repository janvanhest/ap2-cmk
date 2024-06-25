# Abstraction in C#:
Abstraction simplifies complexity by highlighting only the necessary details in a class while hiding its internal mechanisms. This concept is akin to using a TV remote without understanding its inner workings.

## Types of Abstraction in OOP:

1.  **Data Abstraction:** Focuses on constructing complex data types and exposing only essential operations to interact with the data while concealing the implementation details.
2.  **Control Abstraction:** Identifies repetitive statements across software and encapsulates them into methods to streamline programming tasks.

## Achieving Abstraction in C#:
Abstraction in C# is accomplished through interfaces and abstract classes, which allow for complete and partial abstraction respectively. This approach is crucial in structured programming and managing complex data types like Dictionary or HashSet.

**Example of Abstraction using Interfaces:** In C#, interfaces can abstract implementation details, demonstrated by creating an interface `IReport` with a method `Run()`, which is implemented by `EmployeeReport` and `SalaryReport` classes. Execution of these reports is managed in the `Main` class without revealing the internal details of the reports.

## Difference between Encapsulation and Abstraction:

-   **Encapsulation:** Encapsulates code and data together within the same class, protecting the data from external access and misuse.
-   **Abstraction:** Focuses on hiding implementation details, facilitated by abstract classes and interfaces in C#.

# Encapsulation and Abstraction in C#:
Encapsulation and abstraction are two fundamental principles of object-oriented programming (OOP) that help in designing classes for effective software management.

## 1. Encapsulation:

-   **Definition:** Encapsulation involves wrapping data (state) and methods (behavior) within a class while hiding information and implementation details through access modifiers (like `private` in C#). This design principle prevents direct access to class attributes and methods, safeguarding data integrity and ensuring controlled interactions.
-   **Example in C#:** In a `ReportWriter` class, the `defaultLocation` attribute is private, manipulated only via public `SetDefaultLocation` and `GetDefaultLocation` methods. The `WriteReport` method, which uses `defaultLocation`, is public and defines how reports are generated, encapsulating the implementation details.

## 2. Changes and Encapsulation:

-   **Principle:** The design principle "Whatever changes, encapsulate it" suggests that both data, which may change at runtime, and implementation, potentially modified in future updates, should be encapsulated. This strategy allows changes in a class without affecting other parts of the software, as external classes interact with the class only through its public interface.

## 3. Abstraction:

-   **Definition:** Abstraction in C# allows the creation of systems with objects that perform specific functions and interact without revealing how these functions are implemented internally.
-   **Implementation:** This is achieved by defining interfaces or abstract classes where the operations available are declared without detailing the methods' inner workings. For example, a `ReportWriter` class might expose a `WriteReport` method as part of its interface, abstracting the details of how reporting is implemented.

## 4. Relationship Between Encapsulation and Abstraction:

-   **Comparison:** Abstraction concerns what a class does—representing the higher-level functionality, while encapsulation is how these functionalities are achieved through controlled exposure and hiding of the workings.
-   **Illustration in C#:** Consider a `Dictionary<TKey, TValue>` class in C#. From an abstraction perspective, users of the class need to know only about methods like `Add(TKey, TValue)` and `GetValue(TKey)`. The encapsulation aspect involves the internal implementation like how key-value pairs are stored, managed, and accessed, which remains hidden from the user, thus ensuring that the class can be modified without impacting existing code.

# Inheritance in C#

Inheritance is a fundamental concept in object-oriented programming (OOP) that allows a class (child or subclass) to inherit attributes and methods from another class (parent or superclass), promoting code reusability and hierarchical classifications.

## 1. What is Inheritance in C#

- **Mechanism:** In C#, inheritance is facilitated by the `:` symbol, where a child class inherits from a parent class.
- **Example:**

  ```csharp
  public class Parent {
  }

  public class Child : Parent {
  }
  ```

## 2. Inheritance in Action

- **Scenario:** For instance, an `Employee` class defines general attributes (e.g., id, firstName, lastName) and methods. A `Manager` class, which is a type of `Employee`, inherits these and includes additional attributes like a list of subordinates.

  ```csharp
  public class Employee {
      private long id;
      private string firstName;
      private string lastName;
      // Getters and Setters
  }

  public class Manager : Employee {
      private List<Employee> subordinates;

      public Manager(long id, string firstName, string lastName, List<Employee> subordinates) : base(id, firstName, lastName) {
          this.subordinates = subordinates;
      }
  }
  ```
  This prevents duplication of common attributes and methods across these classes.

## 3. Types of Inheritance in C#

- **Single Inheritance:** A single child class inherits from one parent class.
- **Multi-level Inheritance:** A chain of classes where a child class also acts as a parent to another child.
- **Hierarchical Inheritance:** One parent class is extended by multiple child classes.
- **Multiple Inheritance:** Achieved through interfaces since C# does not support direct multiple inheritance from multiple classes. This allows a class to implement multiple interfaces.

## 4. Accessing Members of Parent Class in C#

- **Constructors:** Accessed via the `base` keyword.

  ```csharp
  public class Manager : Employee {
      public Manager() : base() {
          // Initialization code here
      }
  }
  ```
- **Fields:** Non-private fields inherited can be accessed directly; private fields via public getters and setters.
- **Methods:** Non-private methods can be accessed directly. Overridden methods in the child class take precedence.

  ```csharp
  public class Manager : Employee {
      public override string ToString() {
          return $"Manager{{id={GetId()}, firstName='{GetFirstName()}', lastName='{GetLastName()}', subordinates={subordinates}}}";
      }
  }
  ```

## 5. Conclusion

- **Summary:** Inheritance (an IS-A relationship) allows a child class in C# to utilize non-private members of its parent class. It simplifies code maintenance and enhances scalability. From C# 8 onwards, interfaces with default methods can be used to simulate aspects of multiple inheritance.


# Polymorphism in C#

Polymorphism is a core concept in object-oriented programming that allows a class to exhibit different behaviors in different programmatic contexts. It is a fundamental building block along with inheritance, abstraction, and encapsulation.

## 1. What is Polymorphism?

Polymorphism enables a class to perform a single action in different ways. In C#, this is accomplished through interfaces that can be implemented in various ways by different classes while maintaining the same interface.

For example, polymorphism allows an instance of a subclass to be treated as an instance of a superclass, utilizing reference variables of the superclass:

```csharp
Object o = new Object(); // o can hold the reference of any subtype

Object o = "Hello"; // String is a subclass of Object
Object o = 42; // Integer is a subclass of Object
```

## 2. Types of Polymorphism

In C#, polymorphism is primarily divided into two types:

- **Compile-time Polymorphism (Method Overloading):** This form of polymorphism is resolved during the compile time. It is achieved through method overloading where methods have the same name but different parameter lists (number, types, or both).

  For instance, a `Calculator` class can have multiple `Sum` methods accepting different types of parameters:

  ```csharp
  public class Calculator {

    public int Sum(int a, int b) {
      return a + b;
    }

    public float Sum(float a, float b) {
      return a + b;
    }

    public double Sum(double a, double b) {
      return a + b;
    }
  }
  ```

- **Runtime Polymorphism (Method Overriding):** This form of polymorphism is determined at runtime and is implemented by overriding methods in derived classes. For example, an `Animal` class with subclasses `Cat` and `Dog` might define a `MakeNoise` method differently:

  ```csharp
  public class Animal {

    public virtual void MakeNoise() {
      Console.WriteLine("Some sound");
    }
  }

  public class Dog : Animal {

    public override void MakeNoise() {
      Console.WriteLine("Bark");
    }
  }

  public class Cat : Animal {

    public override void MakeNoise() {
      Console.WriteLine("Meow");
    }
  }
  ```

  When the `MakeNoise` method is invoked, the output depends on the actual instance created at runtime.

## 3. Conclusion

Polymorphism in C# allows a variable, function, or object to take on multiple forms, through method overloading and method overriding. While operator overloading is limited in C# (similar to Java), it supports basic operations such as addition and string concatenation using built-in operators.
