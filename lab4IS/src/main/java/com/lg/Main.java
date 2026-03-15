package com.lg;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.List;

public class Main {
    public static void main (String[] args){
        System.out.println("JPA project");
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager em = factory.createEntityManager();

        em.getTransaction().begin();

        User u1 = new User(null, "test_1", "test_2", "Adam", "Kowalski", Sex.MALE);
        User u2 = new User(null, "test_2", "test_2", "Adam", "Kowalski", Sex.MALE);
        User u3 = new User(null, "test_3", "test_2", "Anna", "Kowalska", Sex.FEMALE);
        User u4 = new User(null, "test_4", "test_2", "Piotr", "Nowak", Sex.MALE);
        User u5 = new User(null, "test_5", "test_2", "Maria", "Nowak", Sex.FEMALE);

        em.persist(u1);
        em.persist(u2);
        em.persist(u3);
        em.persist(u4);
        em.persist(u5);

        Role r1 = new Role(null, "ADMIN");
        Role r2 = new Role(null, "USER");
        Role r3 = new Role(null, "MODERATOR");
        Role r4 = new Role(null, "GUEST");
        Role r5 = new Role(null, "SUPERVISOR");

        em.persist(r1);
        em.persist(r2);
        em.persist(r3);
        em.persist(r4);
        em.persist(r5);

        em.getTransaction().commit();

        em.getTransaction().begin();

        User user1 = em.find(User.class, 1L);
        if (user1 != null) {
            user1.setPassword("nowe_haslo_123");
            em.merge(user1);
        }
        em.getTransaction().commit();

        em.getTransaction().begin();
        Role role5 = em.find(Role.class, 5L);
        if (role5 != null) {
            em.remove(role5);
        }
        em.getTransaction().commit();

        em.getTransaction().begin();
        Query query = em.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'");
        List<User> kowalscy = query.getResultList();
        em.getTransaction().commit();

        System.out.println("--- Lista użytkowników o nazwisku Kowalski ---");
        for (User u : kowalscy) {
            System.out.println(u.getFirstName() + " " + u.getLastName() + " (Login: " + u.getLogin() + ")");
        }

        em.getTransaction().begin();
        Query query2 = em.createQuery("SELECT u FROM User u WHERE u.sex = com.lg.Sex.FEMALE");
        List<User> females = query2.getResultList();
        em.getTransaction().commit();

        System.out.println("\n--- Lista kobiet ---");
        for (User u : females) {
            System.out.println(u.getFirstName() + " " + u.getLastName() + " (Płeć: " + u.getSex() + ")");
        }

        em.getTransaction().begin();

        User userWithRoles = new User(null, "test_roles", "pass123", "Tomasz", "Zarobiony", Sex.MALE);
        Role roleA = new Role(null, "EDITOR");
        Role roleB = new Role(null, "PUBLISHER");

        userWithRoles.addRole(roleA);
        userWithRoles.addRole(roleB);

        em.persist(userWithRoles);

        UsersGroup group1 = new UsersGroup(null, "Programiści");
        group1.addUser(userWithRoles);

        em.persist(group1);

        em.getTransaction().commit();

        em.close();
        factory.close();
    }
}