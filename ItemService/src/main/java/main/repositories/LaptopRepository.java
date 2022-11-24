package main.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import main.entities.Laptop;

public interface LaptopRepository extends JpaRepository<Laptop, Long> {

}
