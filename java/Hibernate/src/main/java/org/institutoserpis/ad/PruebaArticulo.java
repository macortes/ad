package org.institutoserpis.ad;
import java.util.*;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
public class PruebaArticulo {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("inicio");
		//LISTAR ARTICULOS
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Articulo> articulos = entityManager.createQuery("from Articulo",Articulo.class).getResultList();
		for(Articulo articulo : articulos){
		/*System.out.printf("%5s %-30s %5s %10\n",
				articulo.getId(),
				articulo.getNombre(),
				articulo.getCategoria(),
				articulo.getPrecio()
				);
				*/
			System.out.println(articulo.getNombre());
			System.out.println(articulo.getId());
		}
		
		
		
				
		entityManager.getTransaction().commit();
		entityManager.close();
		entityManagerFactory.close();
		
		//BORRAR VERSION MUY SIMPLE
		System.out.println("Borrar");
		EntityManagerFactory em = Persistence.createEntityManagerFactory("org.institutoserpis.ad");
		EntityManager entityManager1 = em.createEntityManager();
		entityManager1.getTransaction().begin();
		
		Articulo articulo =entityManager1.find(Articulo.class, 17L);
		entityManager1.remove(articulo);
		
		
		entityManager1.getTransaction().commit();
		
		
		entityManager1.close();
		em.close();

		
		
		
		
		
	}
	

	//BORRAR ARTICULOS
	
	

}
